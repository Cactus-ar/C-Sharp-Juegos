/* https://en.wikipedia.org/wiki/Lo_Shu_Square
 * 
 * Basicamente es un cuadrado con 9 salas representadas
 * con valores del 1 al 9 y que al sumarlas en columnas o filas o en diagonal
 * siempre dan 15
 * ejemplo:
 * 
 *  +-----------+
 *  | 4 | 9 | 2 |   = 15
 *  |---+---+---|
 *  | 3 | 5 | 7 |   = 15
 *  |---+---+---|
 *  | 8 | 1 | 6 |   = 15
 *  +-----------+
 *                \
 *    =   =   =     15
 *    15  15  15
 */

using System;

namespace CuadradoLoShu
{
    class Program
    {
        private static readonly int[,] Tablero = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            int contador = 0;
            do
            {
                contador++;
                
                Intercambiar();

            } while (!EsCuadradoMagico());
            MostrarTablero();
            Console.WriteLine();
            Console.WriteLine("Tomo " + contador + " intercambios.");

        }

        private static void MostrarTablero()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Tablero[i,j] + " ");
                }
                Console.WriteLine();

            }
        }

        private static bool EsCuadradoMagico()
        {
            var tempSuma = Tablero[0, 0] + Tablero[0, 1] + Tablero[0, 2];
            //comparar filas desde el 1 ya que tempsuma tiene el indice 0
            for (int i = 1; i < 3; i++)
            {
                if(Tablero[i,0] + Tablero[i,1] + Tablero[i, 2] != tempSuma)
                {
                    return false;
                }

            }

            //comparar columnas
            for (int i = 0; i < 3; i++)
            {
                if (Tablero[0, i] + Tablero[1, i] + Tablero[2, i] != tempSuma)
                {
                    return false;
                }

            }

            //comparar diagonales
            if (Tablero[0, 0] + Tablero[1, 1] + Tablero[2, 2] != tempSuma)
                return false;
            if (Tablero[0, 2] + Tablero[1, 1] + Tablero[2, 0] != tempSuma)
                return false;

            return true;

        }

        private static void Intercambiar()
        {
            int[] numero_1 = new int[2];
            int[] numero_2 = new int[2];

            numero_1[0] = random.Next(0, 3);
            numero_1[1] = random.Next(0, 3);
            numero_2[0] = random.Next(0, 3);
            numero_2[1] = random.Next(0, 3);

            int tempo = Tablero[numero_1[0], numero_1[1]];
            Tablero[numero_1[0], numero_1[1]] = Tablero[numero_2[0], numero_2[1]];
            Tablero[numero_2[0], numero_2[1]] = tempo;

        }
    }
}
