using System.Reflection.Metadata.Ecma335;

namespace CodiceFiscaleDaSolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto, inserisci il codice fiscale!");
            string cfInput = Console.ReadLine();
            CodiceFiscale codiceFiscale = new CodiceFiscale();
            if (cfInput.Length < 16)
            {
                Console.WriteLine("Devi inserire 16 caratteri!");
            }
            else
            {
                Console.WriteLine("L'acronimo riferito al cognome è: " + codiceFiscale.getAcrNome(cfInput));
                Console.WriteLine("L'acronimo riferito al nome è: " + codiceFiscale.getAcrCognome(cfInput));
                Console.WriteLine("La data di nascita è: ");
                Console.WriteLine(codiceFiscale.getGiorno(cfInput));
                Console.WriteLine(codiceFiscale.getMese(cfInput));
                Console.WriteLine(codiceFiscale.getAnno(cfInput));
                Console.Write("Gli anni che ha sono: ");
                Console.WriteLine(codiceFiscale.getAnni(cfInput));
                Console.Write("Il suo sesso è: ");
                Console.WriteLine(codiceFiscale.getGenere(cfInput));
            }
            
        }
    }
}