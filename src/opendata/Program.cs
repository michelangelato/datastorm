using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using CsvHelper;
using OpenDataProcessor.Models;
using OpenDataProcessor.Services;

namespace OpenDataProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cartellaOpenData = System.AppContext.BaseDirectory;
            while (Path.GetFileName(cartellaOpenData) != "opendata") {
                cartellaOpenData = Path.GetDirectoryName(cartellaOpenData);
            }

            var input = Path.Combine(cartellaOpenData, "input/edifici-con-sopralluoghi-aedes.csv");
            var output = Path.Combine(cartellaOpenData, "output/dati.csv");
            List<Output> records = null;
            //Ottengo l'insieme base
            using (var fileReader = File.OpenText(input)) {
                using (var csv = new CsvReader(fileReader)){
                //csv.Configuration.WillThrowOnMissingField = false;
                csv.Configuration.RegisterClassMap<OutputClassMap>();
                csv.Configuration.Delimiter = ";";

                records = csv.GetRecords<Output>().Where(r => !string.IsNullOrEmpty(r.Agibilita)).ToList();
                }
            }
            //Lo riqualifico con i vari indicatori trovati negli altri fileReader
            Ricostruisci(records, "catene-cordoli-strutture-muratura", o => o.CateneCordoli, 2, new[] { 0, 3, 4 });
            Ricostruisci(records, "numero-piani", o => o.NumeroDiPiani, 11, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 12, 14, 15, 16, 17 });
            Ricostruisci(records, "posizione-edifici", o => o.Posizione, 3, new[] { 0, 2, 4, 5, 7 });
            Ricostruisci(records, "uso", o => o.Uso, 5, new[] { 0, 1, 2, 4, 6, 7, 8, 9 });
            Ricostruisci(records, "eta", o => o.AnnoDiCostruzione, 3, new[] { 0, 1, 4, 5, 6, 7, 8, 10 });
            Ricostruisci(records, "tipologia-costruttiva", o => o.Costruzione, 2, new[] { 0, 3, 4, 5, 6, 8 });
            Ricostruisci(records, "percentuale-utilizzo", o => o.PercentualeUtilizzo, 1, new[] { 2, 3, 4, 5, 6, 7, 8, 9 });

            
            using (var fileWriter = File.Open(output, FileMode.OpenOrCreate, FileAccess.Write)) {
                using (var sw = new StreamWriter(fileWriter)){
                    using (var csv = new CsvWriter(sw)){
                        csv.WriteRecords(records);
                    }
                }
            }



        }

        private static Dictionary<string, Dictionary<string, int>> EstraiDati(string nomeFile, int indiceComune, int[] indici){
            var comuni = new Dictionary<string, Dictionary<string, int>>();
            using (var fileReader = File.OpenText(nomeFile)) {
                 using (var csv = new CsvReader(fileReader)) {
                 csv.Configuration.Delimiter = ";";
                 csv.Configuration.HasHeaderRecord = false;
                 var intestazioni = new Dictionary<int, string>();
                 if (csv.Read()){
                     foreach (var indice in indici){
                         intestazioni.Add(indice, csv.GetField(indice));
                     }
                 }
                 while (csv.Read()) {
                     var comune = csv.GetField(indiceComune);
                     if (!comuni.ContainsKey(comune))
                        comuni.Add(comune, new Dictionary<string, int>());
                    
                    var voci = comuni[comune];
                    foreach (var indice in indici) {
                        var valore = int.Parse(csv.GetField<string>(indice).Replace(",", ""));
                        var intestazione = intestazioni[indice];
                        if (!voci.ContainsKey(intestazione))
                            voci.Add(intestazione, valore);

                        //voci[voce] = voci[voce]+1;
                    }
                    }
                 }
             }
             return comuni;
        }

        private static void Ricostruisci(List<Output> records, string nomeFile, Expression<Func<Output, object>> proprieta, int indiceComune, int[] indici){
            var ricostruttore = new Ricostruttore(proprieta);
            //estrai i valori
            

            var fileInagibili = "input/" + nomeFile + ".inagibili.csv";
            var datiInagibili = EstraiDati(fileInagibili, indiceComune, indici);

            var fileAgibili = "input/" + nomeFile + ".csv";
            var datiAgibili = EstraiDati(fileAgibili, indiceComune, indici);

            var esitiInagibili = new [] { "E", "F" };
             var inagibili = records.Where(r => esitiInagibili.Contains(r.Agibilita)).OrderByDescending(r => r.Agibilita).ToList();
             var agibili = records.Where(r => !esitiInagibili.Contains(r.Agibilita)).OrderByDescending(r => r.Agibilita).ToList();

            var comuni = records.Select(r => r.Comune).Distinct();
            foreach (var comune in comuni) {
               Console.WriteLine(comune); 
            var comuneAgibili = datiAgibili[comune];
            var comuneInagibili = datiInagibili[comune];

            List<Indicatore> indicatori = new List<Indicatore>();
            foreach (var c in comuneAgibili) {
                var i = comuneInagibili[c.Key];

if (i > 0){
                indicatori.Add(new Indicatore{
                    Nome = c.Key,
                    PercentualeInagibili = c.Value <= 0 ? 0 : i * 100 / c.Value,
                    Istanze = i
                });
}



            }

            for (var k = 0; k< inagibili.Count; k++){
            //TODO: riottieni gli indicatori
                var inagibile = inagibili[k];   
                ricostruttore.Ricostruisci(ref inagibile, ref indicatori);
            }
            indicatori.Clear();
                foreach (var c in comuneAgibili) {
                var i = comuneInagibili[c.Key];

if (c.Value-i > 0){
                indicatori.Add(new Indicatore{
                    Nome = c.Key,
                    PercentualeInagibili = c.Value <= 0 ? 0 : i * 100 / c.Value,
                    Istanze = c.Value-i
                });
}



            }

            for (var k = 0; k< agibili.Count; k++) {
                    //TODO riottieni gli indicatori
                    var agibile = agibili[k];
                    ricostruttore.Ricostruisci(ref agibile, ref indicatori);
            }

            }
        }
    }
}
