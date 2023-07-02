using System;
namespace GestioneVeicoli
{
    public class Veicolo
    {
        protected string targa;
        protected string marca;
        protected string modello;
        protected int numeroPosti;

        public string Targa { get => targa; set => targa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        public int NumeroPosti { get => numeroPosti; set => numeroPosti = value; }

        public Veicolo(string targa, string marca, string modello, int numeroPosti)
        {
            this.Targa = targa;
            this.Marca = marca;
            this.Modello = modello;
            this.NumeroPosti = numeroPosti;
        }

        public string toString()
        {
            return $"Targa: {targa}\nMarca: {marca}\nModello {modello}\nNumero posti: {numeroPosti}";
        }
    }
}
