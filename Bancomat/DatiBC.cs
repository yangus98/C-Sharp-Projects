using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat
{
    internal class DatiBC
    {
        const string Pin = "1234";
        public const int maxPrev = 250;
        private int saldo;
        private int tentativi = 1;

        public DatiBC(int saldo)
        {
            this.saldo = saldo; 
        }

        public int Saldo { get => saldo;
            set => saldo = value;
        }

        public bool controlloPin(string pin)
        {
           if(pin != Pin && tentativi <= 3)
            {
                tentativi++;
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
