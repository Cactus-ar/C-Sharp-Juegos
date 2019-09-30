using System;
using System.Collections.Generic;
using System.Text;

namespace CarreraAnimales
{
    /* De aqui derivan todos los animales (u otros objetos que corren la carrera) */

    public abstract class Corredor
    {
        private static Random _rng = new Random();
        public int PosicionOriginal { get; set; }
        public string SimboloDelCorredor { get; set; }  //Representa el simbolo en la pista
        public int PosicionActual { get; set; }
        public int Carril { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public static List<Corredor> Participantes = new List<Corredor>();

        public int TipoDeMovida()
        {
            return _rng.Next(1, 101);
        }

        public void Moverse(int espacios)
        {
            PosicionOriginal = PosicionActual;

            //chequear los limites de la pista de carrera
            if (PosicionActual + espacios < 0)
            {
                PosicionActual = 0;
            }else if (PosicionActual + espacios > Pista.LargoDeLaPista)
            {
                PosicionActual = Pista.LargoDeLaPista;
            }else
            {
                PosicionActual += espacios;
            }

        }

        public bool EsGanador(Corredor corredor)
        {
            if (corredor.PosicionActual == Pista.LargoDeLaPista)
                return true;
            else
                return false;
        }

        public abstract void CalcularMovida(); //Creada de esta forma porque cada corredor va a implementar su estilo de moverse

    }
}
