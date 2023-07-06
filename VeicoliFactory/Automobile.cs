using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliFactory
{
    internal class Automobile : IVeicolo
    {
        private int telaio;
        private string descrizione;
        private string colore;
        private double prezzo;

        public Automobile(int telaio, string descrizione, string colore, double prezzo)
        {
            this.telaio = telaio;
            this.descrizione = descrizione;
            this.colore = colore;
            this.prezzo = prezzo;
        }

        public void fabbrica()
        {
            Console.WriteLine("Telaio auto: " + this.telaio);
            Console.WriteLine("descrizione auto: " + this.descrizione);
            Console.WriteLine("colore auto: " + this.colore);
            Console.WriteLine("prezzo auto: $" + this.prezzo);
            Console.WriteLine("--------------");
        }

        public double getPrezzo()
        {
            return this.prezzo;
        }
    }
}
