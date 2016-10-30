using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using OpenDataProcessor.Models;

namespace OpenDataProcessor.Services {
    public class Ricostruttore {

private readonly PropertyInfo property;
public Ricostruttore (Expression<Func<Output, object>> proprieta)
{
  var memberSelectorExpression = proprieta.Body as MemberExpression;
        if (memberSelectorExpression == null)
        throw new Exception("Non è una MemberExpression");
        
            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property == null)
            throw new Exception("Non è una PropertyInfo");

            this.property = property;
}

 //http://stackoverflow.com/questions/9601707/how-to-set-property-value-using-expressions
        public void Ricostruisci(Output istanza, ref List<Indicatore> indicatori) {

            var percentuali = indicatori.Select(i => i.PercentualeInagibili);
            var somma = percentuali.Sum();
            var random = new Random();
            var numero = random.Next(0, somma);
            var accumulatore = 0;
            var valore = "";
            for (var i = 0; i<indicatori.Count; i++) {
                var indicatore = indicatori[i];
                accumulatore += indicatore.PercentualeInagibili;
                valore = indicatore.Nome;
                if (accumulatore <= somma) {
                    if (indicatore.Istanze <= 1) {
                        indicatori.Remove(indicatore);
                        percentuali = indicatori.Select(ind => ind.PercentualeInagibili);
                        somma = percentuali.Sum();
                    } else {
                        indicatore.Istanze -= 1;
                    }
                    break;
                }
            }
            property.SetValue(istanza, valore, null);
        
        }
    }
}