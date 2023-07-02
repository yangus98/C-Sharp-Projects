using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat
{
    internal class ClasseBancomat
    {
        private int prelievo;

        public int Prelievo { get => prelievo; set => prelievo = value; }


        public bool PrelievoConto(int prelievo, DatiBC datibc)
        {
            if (datibc.Saldo < prelievo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool maxPrev(int prelievo, int maxPrev)
        {
            if (prelievo < maxPrev)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
