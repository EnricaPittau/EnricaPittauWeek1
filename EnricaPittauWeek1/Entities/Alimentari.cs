using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek1.Entities
{
    public class Alimentari : Prodotto
    {
        public int Qnt { get; set; }
        public DateTime DataScadenza { get; set; } // 30.04.22
        public int GiorniMancanoScad { get { return CalcolaGiorni();  } }

        private int CalcolaGiorni()
        {
            return (DataScadenza - DateTime.Today).Days;
        }

        public override string ToString()
        {
            return base.ToString() + $"\r\nQuantità: {Qnt} - Data di scadenza: {DataScadenza} - Giorni che mancano alla scadenza: {CalcolaGiorni()}";
        }
    }
}
