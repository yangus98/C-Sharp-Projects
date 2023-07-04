using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RainbowTheater
{
    internal class ClassiTeatro
    {
        static public string[] postiTotali = new string[10];
        public static int contoPostiLiberi()
        {
            int count = 0;
            foreach (string s in postiTotali)
            {
                if (s == null) count++;
            }
            return count;
        }

        public static void prenota(string nominativo, int posti)
        {
            for (int i = 0; i < postiTotali.Length; i++)
            {
                    if (postiTotali[i] == null && posti > 0)
                    {
                        postiTotali[i] = nominativo;
                        posti--;
                    }
            }
        }

        public static void visualizza()
        {
            for (int i = 0; i < postiTotali.Length; i++)
            {
                if (postiTotali[i] == null)
                {
                    Console.Write(postiTotali[i] + "vuoto ");
                }
                else
                {
                    Console.Write(postiTotali[i] + " ");
                }
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void cancella(string nomeCancellazione)
        {
            for (int i = 0; i < postiTotali.Length; i++)
            {
                if (postiTotali[i] == nomeCancellazione)
                {
                    postiTotali[i] = null;
                }
            }
        }

        public static void guardaPosti(string nominativo)
        {
            for (int i = 0; i < postiTotali.Length; i++)
            {
                if (postiTotali[i] == nominativo)
                {
                    Console.Write(i + 1 + " ");
                }
            }
        }

    }
}
