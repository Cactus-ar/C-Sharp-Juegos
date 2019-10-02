using System;


/*
 * La premisa es simple:
 * Como posicionar 8 damas en un tablero de ajedrez
 * de manera tal que no se ataquen entre ellas
 * 
 * Existen varias soluciones a este problema
 * esta es una muy sencilla usando fuerza bruta
 * 
 */

namespace OchoDamas
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new Resolver();
            resolver.UbicarDamas();
        }
    }
}
