using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterObserver
{
    internal class Utente : IUtente
    {
        private string _nome = "";
        private string _messaggio = "";

        public Utente(string nome)
        {
            _nome = nome;
        }

        public void Aggiorna(string s)
        {
            Console.WriteLine(this._nome + ", ricevuto: " + s);
            this._messaggio = s;
        }
    }
}