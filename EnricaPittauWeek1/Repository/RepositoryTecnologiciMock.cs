using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnricaPittauWeek1.Entities;
using EnricaPittauWeek1.Interfaces;

namespace EnricaPittauWeek1.Repository
{
    internal class RepositoryTecnologiciMock : IRepositoryTecnologici
    {
        static private List<Tecnologici> prodTecnologici = new List<Tecnologici>()
        {
            new Tecnologici() { Codice = "A01", Descrizione = "Modem", Marca = "Logitech", Prezzo = 70, Usato = true},
            new Tecnologici() { Codice = "A02", Descrizione = "Modem", Marca = "Logitech", Prezzo = 70, Usato = false},
            new Tecnologici() { Codice = "A03", Descrizione = "Modem", Marca = "Logitech", Prezzo = 70, Usato = false},
            new Tecnologici() { Codice = "A04", Descrizione = "Modem", Marca = "Logitech", Prezzo = 70, Usato = true}
        };
        public bool Aggiungi(Tecnologici item)
        {
            if (item == null)
                return false;
            prodTecnologici.Add(item);
            return true;
        }

        public List<Tecnologici> GetAll()
        {
            return prodTecnologici;
        }

        public Prodotto GetByCode(string codice)
        {
            foreach (var item in prodTecnologici)
            {
                if (item.Codice==codice)
                {
                    return item;
                }

            }
            return null;
        }

        public Tecnologici GetByMarca(string marca)
        {
            foreach (var item in prodTecnologici)
            {
                if (item.Marca == marca)
                {
                    return item;
                }

            }
            return null;
        }
    }
}
