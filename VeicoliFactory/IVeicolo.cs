using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliFactory
{
    internal interface IVeicolo
    {
        void fabbrica();

        double getPrezzo();
    }
}
