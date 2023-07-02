using System;
namespace GestioneVeicoli
{
    public class Autoveicolo : Veicolo
    {
        private int numeroPorte;

        public Autoveicolo(string targa, string marca, string modello, int numeroPosti, int numeroPorte)
            : base(targa, marca, modello, numeroPosti)
        {
            this.NumeroPorte = numeroPorte;
        }

        public int NumeroPorte { get => numeroPorte; set => numeroPorte = value; }

        public string toString()
        {
            return base.toString() + $"\nNumero di porte: {numeroPorte}";
        }
    }
}
