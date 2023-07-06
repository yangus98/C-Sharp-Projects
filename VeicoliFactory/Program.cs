namespace VeicoliFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            FabbricaVeicoli fab = new FabbricaVeicoli();
            Moto m1 = (Moto)fab.getVeicolo(TipoVeicolo.Moto, "Ducati", "Rosso", 1200.30);
            Camion c1 = (Camion)fab.getVeicolo(TipoVeicolo.Camion, "Fiorino", "Bianco", 2000.23);

            IVeicolo auto1;
            auto1 = fab.getVeicolo(TipoVeicolo.Automobile, "Punto", "Verde", 3002.43);
            Automobile auto2 = (Automobile)fab.getVeicolo(TipoVeicolo.Automobile, "BMW", "Blu", 5000.29);

            List<Moto> motos = new List<Moto>();
            List<Automobile> automobili = new List<Automobile>();
            
            List<IVeicolo> veicoli = new List<IVeicolo>();

            veicoli.Add(m1);
            veicoli.Add(c1);
            veicoli.Add(auto1);
            veicoli.Add(auto2);

            double totPrezzo = 0;

            foreach (var veicolo in veicoli)
            {
                veicolo.fabbrica();
                totPrezzo += veicolo.getPrezzo();
            }

            Console.WriteLine("il valore totale dei veicoli è: $"+ totPrezzo);
        }
    }
}