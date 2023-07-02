using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace RainbowTheater
{
    
    internal class Program
    {
        public static int posti, scelta;
        public static string nominativo, nomeCancellazione;

        static void Main(string[] args)
        {
            {
                while (scelta != 4)
                {
                    Console.WriteLine("---TEATRO ARCOBALENO---");
                    Console.WriteLine("Scegli un opzione:");
                    Console.WriteLine("1 - Prenota fino a 10 posti");
                    Console.WriteLine("2 - Visualizza disponibilità");
                    Console.WriteLine("3 - Cancella prenotazione");
                    Console.WriteLine("4 - Esci");
                    scelta = int.Parse(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            prenota();
                            break;
                        case 2:
                            ClassiTeatro.visualizza();
                            break;
                        case 3:
                            cancella();
                            break;
                        case 4:
                            break;
                    }
                }
            }
        }

        public static void prenota()
        {
            Console.WriteLine("Inserisci il nominativo:");
            nominativo = Console.ReadLine();
            Console.WriteLine("Inserisci il numero dei posti:");
            posti = int.Parse(Console.ReadLine());

            if (ClassiTeatro.contoPostiLiberi() < posti)
            {
                if (ClassiTeatro.contoPostiLiberi() == 0) 
                {
                    Console.WriteLine("Il teatro è pieno");
                }
                else
                {
                    Console.WriteLine("Scegli meno posti, ce ne sono solo " + ClassiTeatro.contoPostiLiberi() + " liberi.");
                }
            }
            else
            {
                if (posti > 10)
                {
                    Console.WriteLine("Puoi prenotare fino a 10 posti. Riprova.");
                    posti = int.Parse(Console.ReadLine());
                }
                else
                {
                    ClassiTeatro.prenota(nominativo, posti);
                    Console.WriteLine("Prenotazione confermata, i posti selezionati sono:");
                    ClassiTeatro.guardaPosti(nominativo);
                    Console.WriteLine(" ");
                }
            }
        }

        public static void cancella() {
            Console.WriteLine("Inserisci il nome della prenotazione da cancellare.");
            nomeCancellazione = Console.ReadLine();
            ClassiTeatro.cancella(nomeCancellazione);
            Console.WriteLine("Cancellazione confermata di "+ nomeCancellazione);
        }
    }
}