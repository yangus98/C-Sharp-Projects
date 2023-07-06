using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliFactory
{
    internal class Camion : IVeicolo
    {
        private int telaio;
        private string descrizione;
        private string colore;
        private double prezzo;

        public Camion(int telaio, string descrizione, string colore, double prezzo)
        {
            this.telaio = telaio;
            this.descrizione = descrizione;
            this.colore = colore;
            this.prezzo = prezzo;
        }

        public void fabbrica()
        {
            Console.WriteLine("Telaio camion: " + this.telaio);
            Console.WriteLine("descrizione camion: " + this.descrizione);
            Console.WriteLine("colore camion: " + this.colore);
            Console.WriteLine("prezzo camion: $" + this.prezzo);
            Console.WriteLine("--------------");
        }

        public double getPrezzo()
        {
            return this.prezzo;
        }
    }
}
