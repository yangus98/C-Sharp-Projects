using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileDecorator
{
    abstract class AutoDecorator : Auto
    {
        public abstract override string Descrizione();
        public abstract override int Prezzo();
    }

}
