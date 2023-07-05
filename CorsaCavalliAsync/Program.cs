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

            cavallo1.OnJob += EventoOnJob;
            cavallo1.OnJob2 += EventoOnJob2;
            cavallo1.EndJob += EventoEndJob;

            cavallo2.OnJob += EventoOnJob;
            cavallo2.OnJob2 += EventoOnJob2;
            cavallo2.EndJob += EventoEndJob;

            cavallo3.OnJob += EventoOnJob;
            cavallo3.OnJob2 += EventoOnJob2;
            cavallo3.EndJob += EventoEndJob;

            var m1 = Task.Run(() => cavallo1.Corsa());
            var m2 = Task.Run(() => cavallo2.Corsa());
            var m3 = Task.Run(() => cavallo3.Corsa());

            await Task.WhenAll(m1, m2, m3);
        }

        static void EventoOnJob(string messaggio)
        {
            Console.WriteLine(messaggio);
        }

        static void EventoOnJob2(string messaggio)
        {
            Console.WriteLine(messaggio);
        }

        static void EventoEndJob(string messaggio)
        {
            Console.WriteLine(messaggio);
        }
    }
}