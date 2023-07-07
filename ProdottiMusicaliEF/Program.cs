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

        delegate void WriteLineDelegate(string message);

        static void Main(string[] args)
        {
            WriteLineDelegate writeLine = Console.WriteLine;
            string scelta;
            do
            {
                writeLine("DATABASE DELLE CANZONI");
                writeLine("");
                writeLine("1 - Visualizza");
                writeLine("2 - Inserisci nuova canzone");
                writeLine("3 - Elimina canzone");
                writeLine("4 - Modifica canzone esistente");
                writeLine("5 - Esci");

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
            WriteLineDelegate writeLine = Console.WriteLine;
            var elenco = from p in ctx.Cds select p;
            foreach (var p in elenco)
            {
                writeLine("");
                writeLine($"id:{p.Id} - titolo:{p.Titolo} - artista:{p.Artista} - anno di pubblicazione:{p.Anno}");
                writeLine("");
            }
        }

        public static void Inserisci()
        {
            Cd cd = new Cd();
            WriteLineDelegate writeLine = Console.WriteLine;

            writeLine("Inserisci il titolo");
            cd.Titolo = (Console.ReadLine());
            writeLine("Inserisci l'artista");
            cd.Artista = (Console.ReadLine());
            writeLine("Inserisci l'anno di pubblicazione");
            cd.Anno = (int.Parse(Console.ReadLine()));

            ctx.Cds.Add(cd);
            ctx.SaveChanges();
        }

        public static void Elimina()
        {
            WriteLineDelegate writeLine = Console.WriteLine;
            writeLine("Inserisci il codice della canzone da eliminare");
            codElimina = int.Parse(Console.ReadLine());
        }

        public static void Modifica()
        {
            WriteLineDelegate writeLine = Console.WriteLine;
            writeLine("Inserisci il codice della canzone da modificare");
            codModifica = int.Parse(Console.ReadLine());

            writeLine("Cosa vuoi modificare? Titolo(t) - Artista(a) - Anno di pubblicazione(y) ?");
            sceltaModifica = Console.ReadLine();

            if (sceltaModifica == "t")
            {
                writeLine("Inserisci come vuoi modificare il titolo");
                titoloModificato = Console.ReadLine();
                writeLine("Modifica effettuata!");
            }
            else if (sceltaModifica == "a")
            {
                writeLine("Inserisci come vuoi modificare l'artista");
                artistaModificato = Console.ReadLine();
                writeLine("Modifica effettuata!");
            }
            else if (sceltaModifica == "y")
            {
                writeLine("Inserisci come vuoi modificare l'anno di pubblicazione");
                annoModificato = int.Parse(Console.ReadLine());
                writeLine("Modifica effettuata!");
            }
            else
            {
                writeLine("Modifica fallita, riprova!");
            }
        }
    }
}