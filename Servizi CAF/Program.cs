namespace CAFdasolo
{
    internal class Program
    {
        public static string nominativo;
        public static int eta, anniLavorativi, mesiOccupazione;
        public static double isee, patrimonioImmobiliare, reddito, bustaPaga;
        static void Main(string[] args)
        {
            Console.WriteLine("Scegli il servizio:");
            Console.WriteLine("1 - RdC");
            Console.WriteLine("2 - Quota100");
            Console.WriteLine("3 - Calcolo Tassazione");
            Console.WriteLine("4 - Naspi");

            string scegli = Console.ReadLine();
            ServiziCAF serviziCAF = new ServiziCAF();

            switch (int.Parse(scegli)) 
            {
                case 1:
                    UsaNominativo();
                    RdC();
                    if (serviziCAF.RdC(nominativo, eta, isee, patrimonioImmobiliare) == true) 
                    {
                        Console.WriteLine(nominativo + " ha diritto al RdC");
                    }
                    else
                    {
                        Console.WriteLine(nominativo + " non ha diritto al RdC");
                    }
                    break;
                case 2:
                    UsaNominativo();
                    Quota100();
                    if (serviziCAF.Quota100(nominativo, eta, anniLavorativi) == true)
                    {
                        Console.WriteLine(nominativo + " ha diritto alla pensione");
                    }
                    else
                    {
                        Console.WriteLine(nominativo + " non ha diritto alla pensione");
                    }
                    break;
                case 3:
                    UsaNominativo();
                    CalcoloTassazione();
                    Console.WriteLine(nominativo + " pagherà " + serviziCAF.CalcoloTassazione(nominativo, reddito)+ " di tasse.");
                    break;
                case 4:
                    UsaNominativo();
                    Naspi();
                    Console.WriteLine(nominativo + " riceverà " + serviziCAF.Naspi(nominativo, bustaPaga, mesiOccupazione)+ " per la disoccupazione.");
                    break;
            }
        }

        public static void UsaNominativo()
        {
            Console.WriteLine("Inserisci nominativo");
            nominativo = Console.ReadLine();
        }

        public static void RdC()
        {
            Console.WriteLine("Inserisci Età");
            eta = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci l'ISEE");
            isee = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il patrimonio immobiliare");
            patrimonioImmobiliare = double.Parse(Console.ReadLine());
        }

        public static void Quota100()
        {
            Console.WriteLine("Inserisci Età");
            eta = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci gli anni lavorativi");
            anniLavorativi = int.Parse(Console.ReadLine());
        }

        public static void CalcoloTassazione()
        {
            Console.WriteLine("Inserisci il reddito 2022");
            reddito = double.Parse(Console.ReadLine());
        }

        public static void Naspi() {
            Console.WriteLine("Inserisci importo netto busta paga");
            bustaPaga = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci i mesi totali di occupazione del tuo lavoro");
            mesiOccupazione = int.Parse(Console.ReadLine());
        }
    }
}