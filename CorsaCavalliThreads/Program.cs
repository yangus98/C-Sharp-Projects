namespace thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            cavallo cavallo1 = new cavallo("Furia", rnd);
            cavallo cavallo2 = new cavallo("Medea", rnd);
            cavallo cavallo3 = new cavallo("Rocky", rnd);

            cavallo1.OnJob += EventoOnJob;
            cavallo1.OnJob2 += EventoOnJob2;
            cavallo1.EndJob += EventoEndJob;

            cavallo2.OnJob += EventoOnJob;
            cavallo2.OnJob2 += EventoOnJob2;
            cavallo2.EndJob += EventoEndJob;

            cavallo3.OnJob += EventoOnJob;
            cavallo3.OnJob2 += EventoOnJob2;
            cavallo3.EndJob += EventoEndJob;

            Thread th1 = new Thread(cavallo1.Corsa);
            Thread th2 = new Thread(cavallo2.Corsa);
            Thread th3 = new Thread(cavallo3.Corsa);

            th1.Start();
            th2.Start();
            th3.Start();
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