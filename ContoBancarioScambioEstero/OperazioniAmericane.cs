using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conto_Bancario_con_scambi
{
    internal class OperazioniAmericane
    {
        public static double balance = 400.50, withdrawal, deposit;
        public static void ControlBalance()
        {
            Console.WriteLine("The balance is " + balance + " $.");
            Console.WriteLine("--------------------");

        }

        public static void Withdrawal()
        {
            Console.WriteLine("Insert the withdrawal...");
            withdrawal = Convert.ToDouble(Console.ReadLine());
            if (balance < withdrawal)
            {
                Console.WriteLine("Insufficient balance, you can to withdrawal until " + balance + " $.");
                Console.WriteLine("--------------------");
            }
            else
            {
                balance = balance - withdrawal;
                Console.WriteLine("You have withdrawal " + withdrawal + " $.");
                Console.WriteLine("--------------------");
            }
        }

        public static void Deposit()
        {
            Console.WriteLine("Insert how much do you want to deposit...");
            deposit = Convert.ToDouble(Console.ReadLine());
            balance = balance + deposit;
            Console.WriteLine("You deposit " + deposit + " $.");
            Console.WriteLine("--------------------");
        }
    }
}
