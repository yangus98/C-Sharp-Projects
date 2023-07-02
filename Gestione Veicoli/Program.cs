using System;
using Microsoft.Data.SqlClient;

namespace GestioneVeicoli
{
    public class Program
    {
        static Autocarro[] autocarri = new Autocarro[5];
        static Autoveicolo[] autoveicoli = new Autoveicolo[5];
        static Veicolo veicolo;
        static int contatoreAutocarri = 0;
        static int contatoreAutoveicoli = 0;
        static Database db = new Database();
        

        public static void Main(String[] args)
        {
            mascheraMenu();
        }

        public static void mascheraMenu()
        {
            string sceltaUtente;
            do
            {
                Console.WriteLine("---GESTIONE AUTOVEICOLI---");
                Console.WriteLine("1 - Inserimento dati autocarro");
                Console.WriteLine("2 - Inserimento dati autoveicolo");
                Console.WriteLine("3 - Visualizza veicoli inseriti");
                Console.WriteLine("4 - Modifica autocarro");
                Console.WriteLine("5 - Fine");
                sceltaUtente = Console.ReadLine()!;

                switch (sceltaUtente)
                {
                    case "1":
                        if (db.ottieniConnessione())
                        {
                            Console.WriteLine("Connessione riuscita");
                            veicoloMaschera();
                            autocarroMaschera();
                        }
                        else
                        {
                            Console.WriteLine("Connessione non riuscita");
                        }
                        db.chiudiConnessione();
                        break;
                    case "2":
                        if (db.ottieniConnessione())
                        {
                            Console.WriteLine("Connessione riuscita");
                            veicoloMaschera();
                            autoveicoloMaschera();
                        }
                        else
                        {
                            Console.WriteLine("Connessione non riuscita");
                        }
                        db.chiudiConnessione();
                        break;
                    case "3":
                        if (db.ottieniConnessione())
                        {
                            Console.WriteLine("Connessione riuscita");
                            toStringVeicoli();
                        }
                        else
                        {
                            Console.WriteLine("Connessione non riuscita");
                        }
                        db.chiudiConnessione();
                        break;
                    case "4":
                        if (db.ottieniConnessione())
                        {
                            Console.WriteLine("Connessione riuscita");
                            Console.WriteLine("Inserisci la targa");
                            string targa = Console.ReadLine();
                            Console.WriteLine("Inserisci la capacità massima");
                            int capacitaMassimaCarico = int.Parse(Console.ReadLine());
                            Console.WriteLine("Dati aggiornati");
                            if(Database.updateAutocarro(capacitaMassimaCarico, targa))
                            {
                                Console.WriteLine("Dati aggiornati");
                                toStringVeicoli();
                            }
                            else
                            {
                                Console.WriteLine("impossibile aggiornare i dati");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Connessione non riuscita");
                        }
                        db.chiudiConnessione();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
            while (sceltaUtente != "5");

        }

        public static void veicoloMaschera()
        {
            Console.WriteLine("Inserisci targa:");
            string targa = Console.ReadLine()!;
            Console.WriteLine("Inserisci marca:");
            string marca = Console.ReadLine()!;
            Console.WriteLine("Inserisci modello:");
            string modello = Console.ReadLine()!;
            Console.WriteLine("Inserisci numero di posti:");
            int numeroPosti = int.Parse(Console.ReadLine()!);
            veicolo = new Veicolo(targa, marca, modello, numeroPosti);
        }

        public static void autocarroMaschera()
        {
            Console.WriteLine("Inserisci la capacità massima di carico:");
            double capacitaMassimaCarico = double.Parse(Console.ReadLine()!);
            Console.WriteLine("");
            if(db.inserisciAutocarro(new Autocarro(veicolo.Targa, veicolo.Marca, veicolo.Modello, veicolo.NumeroPosti, capacitaMassimaCarico))){
                Console.WriteLine("Inserimento avvenuto con successo");
            }
            else
            {
                Console.WriteLine("Inserimento fallito");
            }
        }

        public static void autoveicoloMaschera()
        {
            Console.WriteLine("Inserisci il numero di porte:");
            int numeroPorte = int.Parse(Console.ReadLine()!);
            Console.WriteLine("");
            if (db.inserisciAutoveicolo(new Autoveicolo(veicolo.Targa, veicolo.Marca, veicolo.Modello, veicolo.NumeroPosti, numeroPorte)))
            {
                Console.WriteLine("Inserimento avvenuto con successo");
            }
            else
            {
                Console.WriteLine("Inserimento fallito");
            }
        }

        public static void toStringVeicoli()
        {
            try
            {
                SqlDataReader reader = db.leggiAutocarro();
                Console.WriteLine("TARGA\t MARCA\t MODELLO\t CAPACITA' CARICO\t");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)} {reader.GetDouble(4)}\n");
                }
                reader.Close();
                reader = db.leggiAutoveicolo();
                Console.WriteLine("TARGA\t MARCA\t MODELLO\t NUMERO POSTI\t NUMERO PORTE\t");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)} {reader.GetInt32(4)}\n");
                }
                reader.Close();
            }
            catch (NullReferenceException e)
            {

            }

        }

        public static void escitMaschera()
        {
            Console.WriteLine("Arrivederci!");
        }

    }
}

