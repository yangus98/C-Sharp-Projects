namespace AutomobileDecorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto();

            Console.WriteLine("Auto base (a) o sportiva (b)?");
            string ris = Console.ReadLine();
            if (ris == "a") 
            {
                auto.SetDescrizione("1. Automobile base");
                auto.SetPrezzo(5000); 
            }
            else
            {
                auto.SetDescrizione("2. Automobile sportiva");
                auto.SetPrezzo(50000);
            }

            Console.WriteLine("Vuoi la versione a benzina (a) o a diesel (b) ?");
            ris = Console.ReadLine();
            if (ris == "a")
            {
                auto = new MotoreBenzina(auto);
            }
            else
            {
                auto = new MotoreDiesel(auto);
            }

            Console.WriteLine("Vuoi il sistema di condizionamento? y/n");
            ris = Console.ReadLine();
            if (ris == "y") 
            {
                auto = new Condizionatore(auto);
            }

            Console.WriteLine("Vuoi i cerchi in lega? y/n");
            ris = Console.ReadLine();
            if (ris == "y")
            {
                auto = new Cerchi(auto);
            }

            Console.WriteLine("Vuoi il tetto decapottabile? y/n");
            ris = Console.ReadLine();
            if (ris == "y")
            {
                auto = new Decapottabile(auto);
            }

            Console.WriteLine();
            Console.WriteLine("Configurazione finale:");
            Console.WriteLine(auto.Descrizione());
            Console.WriteLine("-----------------");
            Console.WriteLine("Prezzo: " + auto.Prezzo() + " euro.");
        }
    }
}