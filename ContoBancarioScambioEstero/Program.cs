namespace Conto_Bancario_con_scambi
{
    internal class Program
    {
        public static int scelta;
        public delegate void Saldo();
        public delegate void Preleva();
        public delegate void Deposita();
        public static string modalita = "ita";
        static void Main(string[] args)
        {
            Saldo saldo = OperazioniItaliane.ControllaSaldo;
            Preleva preleva = OperazioniItaliane.Preleva;
            Deposita deposita = OperazioniItaliane.Deposita;

            while (scelta != 5)
            {
                if (modalita == "ita")
                {
                    Console.WriteLine("---BANCA ITALIANA---");
                    Console.WriteLine("Scegli un opzione: ");
                    Console.WriteLine("1 - Saldo");
                    Console.WriteLine("2 - Preleva");
                    Console.WriteLine("3 - Deposita");
                    Console.WriteLine("4 - Cambia conto");
                    Console.WriteLine("5 - Esci");
                }
                else
                {
                    Console.WriteLine("---USA BANK---");
                    Console.WriteLine("Choose an option: ");
                    Console.WriteLine("1 - Balance");
                    Console.WriteLine("2 - Withdrawal");
                    Console.WriteLine("3 - Deposit");
                    Console.WriteLine("4 - Change account");
                    Console.WriteLine("5 - Exit");
                    modalita = "usa";
                }
                    scelta = Convert.ToInt32(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            saldo();
                            break;
                        case 2:
                            preleva();
                            break;
                        case 3:
                            deposita();
                            break;
                        case 4:
                        Console.WriteLine("usa or/o ita???");
                        modalita = Console.ReadLine();
                            if (modalita == "usa")
                            {
                                saldo = OperazioniAmericane.ControlBalance;
                                preleva = OperazioniAmericane.Withdrawal;
                                deposita = OperazioniAmericane.Deposit;
                            }
                            else if(modalita == "ita")
                            {
                                saldo = OperazioniItaliane.ControllaSaldo;
                                preleva = OperazioniItaliane.Preleva;
                                deposita = OperazioniItaliane.Deposita;
                            }
                        else
                        {
                                Console.WriteLine("Cambiamento di account fallito, puoi scegliere usa o ita (minuscolo).");
                                Console.WriteLine("Account changing failed, insert usa or ita (lower letters).");
                        }
                        break;
                        }
                    }
            }     
        }
    }