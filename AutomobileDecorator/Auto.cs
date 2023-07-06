using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileDecorator
{
    internal class Auto
    {
        private string _descrizione = "";
        private int _prezzo = 0;

        public void SetDescrizione(string descrizione)
        {
            this._descrizione = descrizione;
        }

        public void SetPrezzo(int prezzo)
        {
            this._prezzo = prezzo;
        }
        public virtual string Descrizione()
        {
            return _descrizione;
        }

        public virtual int Prezzo()
        {
            return _prezzo;
        }
    }
}
