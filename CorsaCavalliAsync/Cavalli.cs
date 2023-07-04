using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CorsaCavalliAsync
{
    internal class Cavalli
    {
        private string nome;
        private Random random;
        public Cavalli(string nome, Random random)
        {
            this.nome = nome;
            this.random = random;
        }

        public void Corsa()
        {
            Console.WriteLine(this.nome + " sta correndo...");
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(this.random.Next(250, 750));
                    Console.WriteLine(this.nome + " ha percorso il " + i + "° giro.");
                    if (i == 10)
                    {
                        Console.WriteLine(this.nome + " ha finito la corsa.");
                    }
                }
        }
    }
}
