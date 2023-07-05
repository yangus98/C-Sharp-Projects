using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace thread
{
    delegate void DelegatoCavallo(string messaggio);

    internal class cavallo
    {
        private string _nome;
        private Random _random;

        public event DelegatoCavallo OnJob;
        public event DelegatoCavallo OnJob2;
        public event DelegatoCavallo EndJob;

        public cavallo(string nome, Random random)
        {
            this._nome = nome;
            this._random = random;
        }
        public void Corsa()
        {
            OnJob(this._nome + " sta correndo...");

            for (int i = 1; i <= 10; i++)
            {
                OnJob2(this._nome + " è al " + i + "° giro.");
                Thread.Sleep(this._random.Next(250,750));

                if (i == 10)
                {
                    EndJob(this._nome + " ha finito la corsa!");
                }
            }
        }      
    }
}
