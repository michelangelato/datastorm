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

            var input = Path.Combine(cartellaOpenData, "input/14-edifici-con-sopralluoghi-aedes.csv");
            List<Output> records = null;
            //Ottengo l'insieme base
            using (var fileReader = File.OpenText(input)) {
                var csv = new CsvReader(fileReader);
                //csv.Configuration.WillThrowOnMissingField = false;
                csv.Configuration.RegisterClassMap<OutputClassMap>();
                csv.Configuration.Delimiter = ";";

                records = csv.GetRecords<Output>().Where(r => !string.IsNullOrEmpty(r.Agibilita)).ToList();
            }
            //Lo riqualifico con i vari indicatori trovati negli altri fileReader
            Ricostruisci(records, "catene-cordoli-strutture-muratura", output => output.CateneCordoli, 2, new[] { 0, 3, 4 });
            
            foreach (var record in records){
                Console.WriteLine(record.CateneCordoli + " " + record.Agibilita);
            }

        }

        private static void Ricostruisci(List<Output> records, string nomeFile, Expression<Func<Output, object>> proprieta, int indiceComune, int[] indici){
            var ricostruttore = new Ricostruttore(proprieta);
            //estrai i valori
            List<Indicatore> indicatori = new List<Indicatore>();

            var fileInagibili = Path.Combine(nomeFile, ".inagibili.csv");
             using (var fileReader = File.OpenText(fileInagibili)) {
                 var csv = new CsvReader(fileReader);
                 var voci = new Dictionary<string, int>();
                 while (csv.Read()) {
                     //csv.GetField();
                 }
             }

            var esitiInagibili = new [] { "E", "F" };
             var inagibili = records.Where(r => esitiInagibili.Contains(r.Agibilita)).OrderByDescending(r => r.Agibilita);
             var agibili = records.Where(r => !esitiInagibili.Contains(r.Agibilita)).OrderByDescending(r => r.Agibilita);

foreach (var comune in inagibili.GroupBy(r => r.Comune)){
    foreach (var inagibile in comune){
        //TODO: riottieni gli indicatori
        ricostruttore.Ricostruisci(inagibile, ref indicatori);
    }
}

            foreach (var comune in agibili.GroupBy(r => r.Comune) ){
                foreach (var agibile in comune){
                    //TODO riottieni gli indicatori
                    ricostruttore.Ricostruisci(agibile, ref indicatori);
                }
            }
        }
    }
}
