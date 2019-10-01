using System;

/*
 * El programa intenta resolver
 * mediante fuerza bruta
 * el recorrido de un caballo
 * de ajedrez por todo el tablero
 * 
 * si lo consigue, muestra cuantos pasos
 * le tomo y estadisticas
 * 
 */

namespace SaltoACaballo
{
    class Program
    {
        static void Main(string[] args)
        {
            var caballo = new Caballo();
            caballo.Mover();
        }
    }
}
