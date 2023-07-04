namespace CorsaCavalliAsync
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await CavalliAsync();
        }

        static async Task CavalliAsync()
        {
            Random rnd = new Random();

            Cavalli cavallo1 = new Cavalli("Furia", rnd);
            Cavalli cavallo2 = new Cavalli("Gino", rnd);
            Cavalli cavallo3 = new Cavalli("Alfio", rnd);

            var m1 = Task.Run(() => cavallo1.Corsa());
            var m2 = Task.Run(() => cavallo2.Corsa());
            var m3 = Task.Run(() => cavallo3.Corsa());

            await Task.WhenAll(m1, m2, m3);
        }
    }
}