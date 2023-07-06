using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Identity.Client;
using ProdottiMusicaliEF.Models;

namespace ProdottiMusicaliEF
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string scelta;
            
            do
            {
                Console.WriteLine("DATABASE DELLE CANZONI");
                Console.WriteLine();
                Console.WriteLine("1 - Visualizza");
                Console.WriteLine("2 - Inserisci nuova canzone");
                Console.WriteLine("3 - Elimina canzone");
                Console.WriteLine("4 - Modifica canzone esistente");
                Console.WriteLine("5 - Esci");

                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Visualizza();
                        break;
                    case "2":
                        Inserisci();
                        break;
                    case "3":
                        Elimina();
                        break;
                    case "4":
                        Modifica();
                        break;
                    case "5":
                        break;
                }
            } while (scelta != "5");
        }

        public static void Visualizza()
        {
            ProdottiMusicaliContext ctx = new ProdottiMusicaliContext();

            var elenco = from p in ctx.Cds select p;
            foreach (var p in elenco)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"id:{p.Id} - titolo:{p.Titolo} - artista:{p.Artista} - anno di pubblicazione:{p.Anno}");
                Console.WriteLine("---------------");
                Console.WriteLine();
            }
        }

        public static void Inserisci()
        {
            Cd cd = new Cd();
            ProdottiMusicaliContext ctx = new ProdottiMusicaliContext();

            Console.WriteLine("Inserisci il titolo");
            cd.Titolo = (Console.ReadLine());
            Console.WriteLine("Inserisci l'artista");
            cd.Artista = (Console.ReadLine());
            Console.WriteLine("Inserisci l'anno di pubblicazione");
            cd.Anno = (int.Parse(Console.ReadLine()));

            ctx.Cds.Add(cd);
            ctx.SaveChanges();
        }

        public static void Elimina()
        {
            ProdottiMusicaliContext ctx = new ProdottiMusicaliContext();

            Console.WriteLine("Inserisci il codice della canzone da eliminare");
            int codElimina = int.Parse(Console.ReadLine());

            var cd_da_eliminare = (from c in ctx.Cds
                                   where c.Id == codElimina
                                   select c).First();

            ctx.Cds.Remove(cd_da_eliminare);
            ctx.SaveChanges();
        }

        public static void Modifica()
        {
            ProdottiMusicaliContext ctx = new ProdottiMusicaliContext();

            Console.WriteLine("Inserisci il codice della canzone da modificare");
            int codModifica = int.Parse(Console.ReadLine());

            var cdModificato = (from c in ctx.Cds
                                where c.Id == codModifica
                                select c).First();
            
            Console.WriteLine("Cosa vuoi modificare? Titolo(t) - Artista(a) - Anno di pubblicazione(y) ?");
            string sceltaModifica = Console.ReadLine();

            if (sceltaModifica == "t")
            {
                Console.WriteLine("Inserisci come vuoi modificare il titolo");
                string titoloModificato = Console.ReadLine();
                cdModificato.Titolo = titoloModificato;
                ctx.SaveChanges();
                Console.WriteLine("Modifica effettuata!");
            }
            else if (sceltaModifica == "a")
            {
                Console.WriteLine("Inserisci come vuoi modificare l'artista");
                string artistaModificato = Console.ReadLine();
                cdModificato.Artista = artistaModificato;
                ctx.SaveChanges();
                Console.WriteLine("Modifica effettuata!");
            }
            else if (sceltaModifica == "y")
            {
                Console.WriteLine("Inserisci come vuoi modificare l'anno di pubblicazione");
                int annoModificato = int.Parse(Console.ReadLine());
                cdModificato.Anno = annoModificato;
                ctx.SaveChanges();
                Console.WriteLine("Modifica effettuata!");
            }
            else
            {
                Console.WriteLine("Modifica fallita, riprova!");
            }
        }

    }
}