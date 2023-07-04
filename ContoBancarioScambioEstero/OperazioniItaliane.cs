using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conto_Bancario_con_scambi
{
    internal class OperazioniItaliane
    {
        public static double saldo = 200.50, prelievo, deposito;
        public static void ControllaSaldo()
        {
            Console.WriteLine("il saldo è " + saldo + " $.");
            Console.WriteLine("--------------------");

        }

        public static void Preleva()
        {
            Console.WriteLine("Inserisci quanto vuoi prelevare...");
            prelievo = Convert.ToDouble(Console.ReadLine());
            if (saldo < prelievo)
            {
                Console.WriteLine("Saldo insufficiente, puoi prelevare fino a " + saldo + " $.");
                Console.WriteLine("--------------------");
            }
            else
            {
                saldo = saldo - prelievo;
                Console.WriteLine("Hai prelevato " + prelievo + " $.");
                Console.WriteLine("--------------------");
            }
        }

        public static void Deposita()
        {
            Console.WriteLine("Inserisci quanto vuoi depositare...");
            deposito = Convert.ToDouble(Console.ReadLine());
            saldo = saldo + deposito;
            Console.WriteLine("Hai depositato " + deposito + " $.");
            Console.WriteLine("--------------------");
        }
    }
}
