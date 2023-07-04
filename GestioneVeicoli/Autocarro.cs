using System;
namespace GestioneVeicoli
{
    public class Autocarro : Veicolo
    {
        private double capacitaMassimaCarico;

        public Autocarro(string targa, string marca, string modello, int numeroPosti, double capacitaMassimaCarico )
            : base(targa, marca, modello, numeroPosti)
        {
            this.CapacitaMassimaCarico = capacitaMassimaCarico;
        }

        public double CapacitaMassimaCarico { get => capacitaMassimaCarico; set => capacitaMassimaCarico = value; }

        public string toString()
        {
            return base.toString() + $"\nCapacità massima di carico: {capacitaMassimaCarico}";
        }
    }
}