using System;

namespace TorreDeHanoi
{
    class Program
    {
        static int movidas = 0;

        static void Main(string[] args)
        {
            var discos = 0;
            Console.WriteLine("\t         Torre de Hanoi");
            Console.WriteLine("\t------------------------------------");
            Console.WriteLine("\tLa idea es mostrar la solucion" );
            Console.WriteLine("\tdel juego dependiendo de la cantidad");
            Console.WriteLine("\tde discos (usando fuerza bruta)");
            Console.WriteLine("\t------------------------------------");
            Console.WriteLine();
            Console.WriteLine("\t\t |\t |\t | ");
            Console.WriteLine("\t\t---\t---\t---");
            Console.WriteLine("\t------------------------------------");
            Console.WriteLine("\tEl formato muestra las movidas desde");
            Console.WriteLine("\tla clavija de origen a la de destino");
            Console.WriteLine("\t------------------------------------");
            Console.WriteLine();

            Console.Write("\tIngrese la cantidad de discos: ");
            discos = Convert.ToInt32(Console.ReadLine());

            Torre(discos, 1, 3, 2); 
        }

        static void Torre(int disco, int paloOrigen, int paloDestino, int paloPaso)
        {
            if (disco == 1)
            {
                Console.WriteLine("\tMovida " + movidas + ": " + paloOrigen + " -> " + paloDestino);
                movidas++;
            }
            else
            {
                Torre(disco - 1, paloOrigen, paloPaso, paloDestino);
                Console.WriteLine("\tMovida " + movidas + ": " + paloOrigen + " -> " + paloDestino);
                movidas++;
                Torre(disco - 1, paloPaso, paloDestino, paloOrigen);
            }
        }
    }
}
