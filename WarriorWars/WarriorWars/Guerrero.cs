using System;
using System.Collections.Generic;
using System.Text;


namespace WarriorWars
{
    class Guerrero
    {

        private const int inicial_VidaAlianza = 100;
        private const int inicial_VidaHorda = 100;


        private readonly Faccion faccion;
        private int vida;
        private string nombre;
        private bool estaVivo;

        public bool EstaVivo {

            get
            {
                return estaVivo;
            }
        }


        private Arma arma;
        private Armadura armadura;

        public Guerrero(string nombre, Faccion faccion)
        {
            this.nombre = nombre;
            this.faccion = faccion;
            estaVivo = true;

            switch (faccion)
            {
                case Faccion.Alianza:
                    arma = new Arma(faccion);
                    armadura = new Armadura(faccion);
                    vida = inicial_VidaAlianza;
                    break;

                case Faccion.Horda:
                    arma = new Arma(faccion);
                    armadura = new Armadura(faccion);
                    vida = inicial_VidaHorda;
                    break;
                default:
                    break;
            }


        }


        public void Ataque(Guerrero enemigo)
        {
            int danio = arma.Danio / enemigo.armadura.PuntosArmadura;

            enemigo.vida -= danio;

            if (enemigo.vida <= 0)
            {
                enemigo.estaVivo = false;
                Console.WriteLine($"{enemigo.nombre} esta muerto..");
            }else
            {
                Console.WriteLine($"{nombre} ataca a {enemigo.nombre} y lo daña por {danio}");
            }

        }
    }
}
