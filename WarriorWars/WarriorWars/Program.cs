using System;
using System.Threading;

namespace WarriorWars
{
    class Program
    {

        static Random rng = new Random();

        static void Main(string[] args)
        {
            Guerrero orco = new Guerrero("Thrall", Faccion.Horda);
            Guerrero humano = new Guerrero("Arthas", Faccion.Alianza);

            while (orco.EstaVivo && humano.EstaVivo)
            {
                if (rng.Next(0,10) < 5)
                {
                    orco.Ataque(humano);
                }else
                {
                    humano.Ataque(orco);
                }

                Thread.Sleep(500);

            }
        }
    }
}
