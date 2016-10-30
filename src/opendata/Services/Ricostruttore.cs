using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using OpenDataProcessor.Models;

namespace OpenDataProcessor.Services {
    public class Ricostruttore {

private readonly PropertyInfo property;
private readonly Random random;
public Ricostruttore (Expression<Func<Output, object>> proprieta)
{
    this.random = new Random();
  var memberSelectorExpression = proprieta.Body as MemberExpression;
        if (memberSelectorExpression == null)
        throw new Exception("Non è una MemberExpression");
        
            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property == null)
            throw new Exception("Non è una PropertyInfo");

            this.property = property;
}

 //http://stackoverflow.com/questions/9601707/how-to-set-property-value-using-expressions
        public void Ricostruisci(ref Output istanza, ref List<Indicatore> indicatori) {

            var percentuali = indicatori.Select(i => i.PercentualeInagibili);
            var somma = percentuali.Sum();
            
            var numero = random.Next(0, somma);
            var accumulatore = 0;
            var valore = "";
            for (var i = 0; i<indicatori.Count; i++) {
                var indicatore = indicatori[i];
                accumulatore += indicatore.PercentualeInagibili;
                valore = indicatore.Nome;
                if (accumulatore >= numero) {
                    if (indicatore.Istanze <= 1) {
                        //Console.WriteLine("Elimino " + indicatore.Nome);
                        indicatori.Remove(indicatore);
                        percentuali = indicatori.Select(ind => ind.PercentualeInagibili);
                        property.SetValue(istanza, valore, null);
                    } else {
                        indicatore.Istanze -= 1;
                        property.SetValue(istanza, valore, null);
                    }
                    //Console.Write("#" + valore);
                    break;
                }
            }
        
        
        }
    }
}