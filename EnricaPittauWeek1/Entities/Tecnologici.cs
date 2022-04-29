using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek1.Entities
{
    public class Tecnologici : Prodotto
    {
        public string Marca { get; set; }
        public bool Usato { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\r\nMarca: {Marca} - L'articolo è usato: {Usato}";
        }
    }
}
