using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Identity.Client;
using ProdottiMusicaliEF.Models;

namespace ProdottiMusicaliEF
{
    internal class Program
    {
        static int codElimina, codModifica, annoModificato;
        static string sceltaModifica, titoloModificato, artistaModificato;
        static ProdottiMusicaliContext ctx = new ProdottiMusicaliContext();

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
                        Cd.Elimina(codElimina);
                        break;
                    case "4":
                        Modifica();
                        Cd.Modifica(codModifica, sceltaModifica, titoloModificato, artistaModificato, annoModificato);
                        break;
                    case "5":
                        break;
                }
            } while (scelta != "5");
        }

        public static void Visualizza()
        {
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
            Console.WriteLine("Inserisci il codice della canzone da eliminare");
            codElimina = int.Parse(Console.ReadLine());
        }

        public static void Modifica()
        {
            Console.WriteLine("Inserisci il codice della canzone da modificare");
            codModifica = int.Parse(Console.ReadLine());

            Console.WriteLine("Cosa vuoi modificare? Titolo(t) - Artista(a) - Anno di pubblicazione(y) ?");
            sceltaModifica = Console.ReadLine();

            if (sceltaModifica == "t")
            {
                Console.WriteLine("Inserisci come vuoi modificare il titolo");
                titoloModificato = Console.ReadLine();
                Console.WriteLine("Modifica effettuata!");
            }
            else if (sceltaModifica == "a")
            {
                Console.WriteLine("Inserisci come vuoi modificare l'artista");
                artistaModificato = Console.ReadLine();
                Console.WriteLine("Modifica effettuata!");
            }
            else if (sceltaModifica == "y")
            {
                Console.WriteLine("Inserisci come vuoi modificare l'anno di pubblicazione");
                annoModificato = int.Parse(Console.ReadLine());
                Console.WriteLine("Modifica effettuata!");
            }
            else
            {
                Console.WriteLine("Modifica fallita, riprova!");
            }
        }
    }
}