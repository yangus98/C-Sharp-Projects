using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CorsaCavalliAsync
{
    delegate void DelegatoCavallo(string messaggio);

    internal class Cavalli
    {
        private string nome;
        private Random random;

        public event DelegatoCavallo OnJob;
        public event DelegatoCavallo OnJob2;
        public event DelegatoCavallo EndJob;

        public Cavalli(string nome, Random random)
        {
            this.nome = nome;
            this.random = random;
        }

        public void Corsa()
        {
            OnJob(this.nome + " sta correndo...");
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(this.random.Next(250, 750));
                    OnJob2(this.nome + " ha percorso il " + i + "° giro.");
                    if (i == 10)
                    {
                        EndJob(this.nome + " ha finito la corsa.");
                    }
                }
        }
    }
}
