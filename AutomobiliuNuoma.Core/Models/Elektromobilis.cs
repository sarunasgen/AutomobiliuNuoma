using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Models
{
    public class Elektromobilis : Automobilis
    {
        public int BaterijosTalpa { get; set; }
        public int IkrovimoLaikas { get; set; }
        public Elektromobilis(int id, string marke, string modelis, decimal nuomosKaina, int baterijosTalpa, int ikrovimoLaikas) 
            : base(id,marke,modelis,nuomosKaina)
        {
            BaterijosTalpa = baterijosTalpa;
            IkrovimoLaikas = ikrovimoLaikas;
        }
        public Elektromobilis(string marke, string modelis, decimal nuomosKaina, int baterijosTalpa, int ikrovimoLaikas)
            : base(marke, modelis, nuomosKaina)
        {
            BaterijosTalpa = baterijosTalpa;
            IkrovimoLaikas = ikrovimoLaikas;
        }
        public override string ToString()
        {
            return $"{Id} {Marke} {Modelis} {NuomosKaina} {BaterijosTalpa}kwh {IkrovimoLaikas} val.";
        }
    }
}
