using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnricaPittauWeek1.Entities;
using EnricaPittauWeek1.Interfaces;

namespace EnricaPittauWeek1.Repository
{
    internal class RepositoryAlimentariFile : IRepositoryAlimentari
    {
        string path = @"C:\Users\Enrica\Desktop\Preacademy\Week8Renata\Enrica\EnricaPittauWeek1\EnricaPittauWeek1\Repository\MagazzinoAlimentari.txt";
        public bool Aggiungi(Alimentari item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice},{item.Descrizione},{item.Prezzo},{item.Qnt}.{item.DataScadenza},{item.GiorniMancanoScad}");
            }
            return true;
        }

        public List<Alimentari> GetAll()
        {
            List<Alimentari> alimentari = new List<Alimentari>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();

                if (string.IsNullOrEmpty(contenutoFile))
                {
                    return alimentari;
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split(",");
                        Alimentari a = new Alimentari();
                        a.Codice = campiDellaRiga[0];
                        a.Descrizione = campiDellaRiga[1];
                        a.Prezzo = double.Parse(campiDellaRiga[2]);
                        alimentari.Add(a);
                    }
                }
                return alimentari;
            }
            
        }

        public Prodotto GetByCode(string codice)
        {
            throw new NotImplementedException();
        }
    }
}
