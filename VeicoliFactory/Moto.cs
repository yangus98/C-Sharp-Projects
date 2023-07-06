using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliFactory
{
    internal class Moto : IVeicolo
    {
        private int telaio;
        private string descrizione;
        private string colore;
        private double prezzo;

        public Moto(int telaio, string descrizione, string colore, double prezzo)
        {
            this.telaio = telaio;
            this.descrizione = descrizione;
            this.colore = colore;
            this.prezzo = prezzo;
        }

        public void fabbrica()
        {
            Console.WriteLine("Telaio moto: "+ this.telaio);
            Console.WriteLine("descrizione moto: " + this.descrizione);
            Console.WriteLine("colore moto: " + this.colore);
            Console.WriteLine("prezzo moto: $" + this.prezzo);
            Console.WriteLine("--------------");
        }
        public double getPrezzo()
        {
            return this.prezzo;
        }

    }
}
