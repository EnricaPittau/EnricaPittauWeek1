using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek1.Entities
{
    public abstract class Prodotto
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }

        public override string ToString()
        {
            return $"Codice {Codice} - Descrizione {Descrizione} - Prezzo {Prezzo}";
        }
    }
}
