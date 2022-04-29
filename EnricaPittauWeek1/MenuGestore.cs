using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnricaPittauWeek1.Entities;
using EnricaPittauWeek1.Interfaces;
using EnricaPittauWeek1.Repository;

namespace EnricaPittauWeek1
{
    public static class MenuGestore
    {
        static IRepositoryAlimentari repoAlimentari = new RepositoryAlimentariMock();
        static IRepositoryTecnologici repoTecnologici = new RepositoryTecnologiciMock();
        internal static void Start()
        {
            bool continua = true;
            while (continua)
            {
                int scelta = Menu();
                continua = AnalizzaScelta(scelta);
            }
        }

        internal static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaTuttiProdotti();
                    break;
                case 2:
                    VisualizzaProdottiAlimentari();
                    break;
                case 3:
                    VisualizzaProdottiTecnologici();
                    break;
                case 4:
                    AggiungiNuovoPrAlimentare();
                    break;
                case 5:
                    AggiungiNuovoPrTecnologico();
                    break;
                case 6:
                    CercaAlimentareCodice();
                    break;
                case 7:
                    CercaTecnologicoMarca();
                    break;
                case 8:
                    VisualizzaTecnoNuovi();
                    break;
                case 9:
                    VisualizzaAlimScadenzaOggi();
                    break;
                case 10:
                    VisualizzaAlimScadInfTreG();
                    break;
                case 0:
                    Console.WriteLine("Arrivederici");
                    return false;
                default:
                    break;
            }
            return true;
        }
        private static void VisualizzaAlimScadInfTreG()
        {
            var listaTecnoFiltroScadInfTreG = repoAlimentari.GetAll();
            foreach (var item in listaTecnoFiltroScadInfTreG)
            {
                if (item.GiorniMancanoScad <= 3)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        private static void VisualizzaAlimScadenzaOggi()
        {
            var listaTecnoFiltroScadOggi = repoAlimentari.GetAll();
            foreach (var item in listaTecnoFiltroScadOggi)
            {
                if (item.GiorniMancanoScad == 0)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        private static void VisualizzaTecnoNuovi()
        {
            var listaTecnoFiltroNuovo = repoTecnologici.GetAll();
            foreach (var item in listaTecnoFiltroNuovo)
            {
                if (item.Usato == false)
                {
                    Console.WriteLine(item.ToString());
                }
            }            
        }
        private static void CercaAlimentareCodice()
        {
            Console.WriteLine("Inserisci il codice da cercare: ");
            string code = Console.ReadLine();
            var listaAlim = repoAlimentari.GetByCode(code);
            if (listaAlim == null)
            {
                Console.WriteLine("Codice inesistente");
            }
            else 
            {
                Console.WriteLine(listaAlim.ToString);
            }       
        }
        private static void CercaTecnologicoMarca()
        {
            Console.WriteLine("Inserisci la marca da cercare: ");
            string marca = Console.ReadLine();
            var listaTecno = repoTecnologici.GetByMarca(marca);
            if (listaTecno == null)
            {
                Console.WriteLine("Marca non presente");
            }
            else
            {
                Console.WriteLine(listaTecno.ToString);
            }
        }
        private static void AggiungiNuovoPrAlimentare()
        {   
            //inserisce i dati richiesti
            Console.WriteLine("Inserisci codice: ");
            string code = Console.ReadLine();   
            Console.WriteLine("Inserisci descrizione: ");
            string descrizione = Console.ReadLine();    
            Console.WriteLine("Inserisci prezzo: ");
            double prezzo;
            double.TryParse(Console.ReadLine(), out prezzo);
            Console.WriteLine("Inserisci quantità: ");
            int qnt;
            int.TryParse(Console.ReadLine(), out qnt);
            
            DateTime scadenza;
            do
            {
                Console.WriteLine("Inserisci data di scadenza: ");
            } while (DateTime.TryParse(Console.ReadLine(), out scadenza) && scadenza> DateTime.Now);

           

            //creo il nuovo prodotto
            var nuovoProdAlim = new Alimentari() { Codice = code, Descrizione = descrizione, Qnt = qnt, DataScadenza = scadenza};
            var esito = repoAlimentari.Aggiungi(nuovoProdAlim);
            if (esito == true)
            {
                Console.WriteLine("Prodotto aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("Errore");
            }


        }
        private static void AggiungiNuovoPrTecnologico()
        {
            string code;
            do
            {
                Console.WriteLine("Inserisci codice: ");
                code = Console.ReadLine();

            } while (!(repoTecnologici.GetByCode(code)==null));

            Console.WriteLine("Codice inserito correttamente!");
            
            Console.WriteLine("Inserisci descrizione: ");
            string descrizione = Console.ReadLine();
            Console.WriteLine("Inserisci prezzo: ");
            double prezzo;
            double.TryParse(Console.ReadLine(), out prezzo);
            Console.WriteLine("Inserisci marca: ");
            string marca = Console.ReadLine();  
            Console.WriteLine("Inserisci se è usato: ");
            bool usato;
            bool.TryParse(Console.ReadLine(),out usato);
            //crea prodotto
            var nuovoProdTecno = new Tecnologici() { Codice = code, Descrizione = descrizione, Marca = marca, Prezzo = prezzo, Usato = usato };
            var esito = repoTecnologici.Aggiungi(nuovoProdTecno);
            if (esito == true)
            {
                Console.WriteLine("Prodotto aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("Errore");
            }
        }
        private static void VisualizzaTuttiProdotti()
        {
            Console.WriteLine("I prodotti in magazzino sono: ");
            var listaAlimRecuperata = repoAlimentari.GetAll();
            var listaTecnoRecuperata = repoTecnologici.GetAll();
            List<Prodotto> listaMagazzino = new List<Prodotto>();
            listaMagazzino.AddRange(listaAlimRecuperata);
            listaMagazzino.AddRange(listaTecnoRecuperata);
            foreach (var p in listaMagazzino)
            {
                Console.WriteLine(p.ToString());
            }           
        }
        private static void VisualizzaProdottiTecnologici()
        {
            
            var listaTecnoRecuperata = repoTecnologici.GetAll();
            if (listaTecnoRecuperata.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Elenco dei prodotti tecnologici presenti: ");
                foreach (var r in listaTecnoRecuperata)
                {
                    Console.WriteLine(r.ToString());
                }
            }
        }
        private static void VisualizzaProdottiAlimentari()
        {
            
            var listaAlimRecuperata = repoAlimentari.GetAll();
            if (listaAlimRecuperata.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Elenco dei prodotti alimentari presenti: ");
                foreach (var r in listaAlimRecuperata)
                {
                    Console.WriteLine(r.ToString());
                }
            }
        }

        private static int Menu()
        {
            Console.WriteLine("**Menu**");
            Console.WriteLine("1. Visualizza tutti i prodotti presenti in magazzino;");
            Console.WriteLine("2. Visualizza i prodotti alimentari;");
            Console.WriteLine("3. Visualizza i prodotti tecnologici");
            Console.WriteLine("4. Aggiungi un nuovo prodotto alimentare.");
            Console.WriteLine("5. Aggiungi un nuovo prodotto tecnologico.");
            Console.WriteLine("6. Cerca un prodotto alimentare per codice;");
            Console.WriteLine("7. Cerca un prodotto tecnologico per Marca;");
            Console.WriteLine("8. Visualizza i Prodotti Tecnologici nuovi");
            Console.WriteLine("9. Visualizza i prodotti alimentari in scadenza oggi");
            Console.WriteLine("10. Visualizza i prodotti alimentari che scadono tra meno 3 giorni");
            Console.WriteLine("\n0. Exit");
            int sceltaUtente;
            do
            {
                Console.WriteLine("\nFai la tua scelta: ");
            } while (!(int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente >= 0 && sceltaUtente <= 10));
            return sceltaUtente;
        }
    }
}
