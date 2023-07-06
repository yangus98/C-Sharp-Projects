using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterObserver
{
    internal class Profilo
    {
        private string _nome = "";
        private string _messaggio = "";
        private List<IUtente> utenti = new List<IUtente>();

        public Profilo(string nome)
        {
            _nome = nome;
            this._messaggio = "Buongiornissimo KAFFEEEE?!?! Come state?";
        }

        public void addUtente(IUtente utente)
        {
            this.utenti.Add(utente);
            utente.Aggiorna(this._messaggio);
        }

        public void removeUtente(IUtente utente)
        {
            this.utenti.Remove(utente);
        }

        public void Notifica(string messaggio)
        {
            this._messaggio = messaggio;
            foreach (var o in this.utenti)
            {
                o.Aggiorna(messaggio);
            }
        }
    }
}
