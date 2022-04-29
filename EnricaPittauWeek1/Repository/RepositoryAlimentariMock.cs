using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnricaPittauWeek1.Entities;
using EnricaPittauWeek1.Interfaces;

namespace EnricaPittauWeek1.Repository
{
    internal class RepositoryAlimentariMock : IRepositoryAlimentari
    {
        static private List<Alimentari> prodAlimentari = new List<Alimentari>()
        {
            new Alimentari() { Codice = "B01", Descrizione = "CocaCola", Prezzo = 1, DataScadenza = new DateTime (2022, 04, 30 ), Qnt = 2 },
            new Alimentari() { Codice = "B02", Descrizione = "Birra", Prezzo = 1, DataScadenza = new DateTime (2022, 04, 29 ), Qnt = 1 },
            new Alimentari() { Codice = "B03", Descrizione = "Aranciata", Prezzo = 1, DataScadenza = new DateTime (2025, 05, 01 ), Qnt = 5 },
            new Alimentari() { Codice = "B04", Descrizione = "The", Prezzo = 1, DataScadenza = new DateTime (2026, 05, 01 ), Qnt = 6 },           
        };
        public bool Aggiungi(Alimentari item)
        {
            if (item == null)
                return false;
            prodAlimentari.Add(item);
            return true;
        }

        public List<Alimentari> GetAll()
        {
            return prodAlimentari;
        }

        public Prodotto GetByCode(string codice)
        {
            foreach (var item in prodAlimentari)
            {
                if (item.Codice == codice)
                {
                    return item;
                }

            }
            return null;
        }

        Alimentari IRepository<Alimentari>.GetByCode(string codice)
        {
            throw new NotImplementedException();
        }
    }
}
