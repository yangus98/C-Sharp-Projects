using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileDecorator
{
    internal class MotoreDiesel : AutoDecorator
    {
        private Auto _auto;

        private string _descrizione = "Motore a Diesel aggiunto!";
        private int _prezzo = 900;

        public MotoreDiesel(Auto auto)
        {
            _auto = auto;
        }
        public override string Descrizione()
        {
            return this._auto.Descrizione() + "\n - " + this._descrizione;
        }

        public override int Prezzo()
        {
            return this._auto.Prezzo() + this._prezzo;
        }
    }
}
