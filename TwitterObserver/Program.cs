namespace TwitterObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Profilo PaginaVip = new Profilo("Pagina Vip");

            Utente Fragola86 = new Utente("Fragola86");
            Utente Kiwi74 = new Utente("Kiwi74");

            PaginaVip.addUtente(Kiwi74);

            Thread.Sleep(1000);
            PaginaVip.Notifica("oggi vado al parrucchiere XD");

            Thread.Sleep(2000);
            PaginaVip.Notifica("forza Napoliiiii!!!!");

            PaginaVip.removeUtente(Kiwi74);
            PaginaVip.addUtente(Fragola86);

            Thread.Sleep(3000);
            PaginaVip.Notifica("fatteli a caschetto!");

        }
    }
}