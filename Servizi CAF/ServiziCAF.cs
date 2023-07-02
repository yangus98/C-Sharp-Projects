using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CAFdasolo
{
    internal class ServiziCAF
    {
        public bool RdC(string nominativo, int eta, double isee, double patrimonioImmobiliare)
        {
            if (
                eta >= 26
                && eta <= 67
                && isee <= 9360
                && patrimonioImmobiliare <= 30000
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Quota100(string nominativo, int eta, int anniLavorativi)
        {
            if (eta + anniLavorativi >= 100) { return true; } else { return false; }

        }

        public double CalcoloTassazione(string nominativo, double reddito)
        {
            double primoScaglione = 15000 * 23 / 100;
            double secondoScaglione = 13000 * 27 / 100;
            double terzoScaglione = 27000 * 38 / 100;
            double quartoScaglione = 20000 * 41 / 100;
            double tasse;

            if (reddito > 75000)
            {
                tasse = ((reddito - 75000) * 43 / 100) + primoScaglione + secondoScaglione + terzoScaglione + quartoScaglione;
            }
            else
            {
                if (reddito > 55000)
                {
                    tasse = ((reddito - 55000) * 41 / 100) + primoScaglione + secondoScaglione + terzoScaglione;
                }
                else
                {
                    if (reddito > 28000)
                    {
                        tasse = ((reddito - 28000) * 38 / 100) + primoScaglione + secondoScaglione;
                    }
                    else
                    {
                        if (reddito > 15000)
                        {
                            tasse = ((reddito - 15000) * 27 / 100) + primoScaglione;
                        }
                        else
                        {
                            tasse = reddito * 23 / 100;
                        }

                    }
                }
            }
            return tasse;
        }

        public double Naspi(string nominativo, double bustaPaga, int mesiOccupazione)
        {
            double sussidio;
            if (mesiOccupazione >= 24)
            {
                sussidio = bustaPaga * 70 / 100;
            }
            else
            {
                sussidio = bustaPaga * 40 / 100;
            }

            if (sussidio > 1200)
            {
                sussidio = 1200;
            }
            return sussidio;
        }
    }
}