using System;
using System.Collections.Generic;
using System.Text;

namespace SaltoACaballo
{
    public class Tablero
    {
        public const int tamanio = 8;
        public const char simboloCasilla = '.';
        public const char simboloMovida = 'X';
        private int[] _horizontal;
        private int[] _vertical;
        public int[] Horizontal { get { return _horizontal; } }
        public int[] Vertical { get { return _vertical; } }
        public char[,] TableroAjedrez { get; set; }

        public Tablero()
        {
            _horizontal = new[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            _vertical = new[] { -1, -2, -2, -1, 1, 2, 2, 1 };
            TableroAjedrez = new char[tamanio, tamanio];
        }

        public void MostrarTablero()
        {
            Console.Write(" ");
            for (int i = 65; i < tamanio + 65; i++) //arrancando de la letra A, en ascii es 65
                Console.Write(Convert.ToChar(i));

            Console.WriteLine();

            for (int r = 0; r < tamanio; r++)
            {
                Console.Write(r + 1);
                for (int c = 0; c < tamanio; c++)
                {
                    Console.Write(TableroAjedrez[r, c]);
                }
                Console.WriteLine();
            }
        }

        public void PoblarArray(int posH, int posV)
        {
            for (int i = 0; i < tamanio; i++)
            {
                for (int c = 0; c < tamanio; c++)
                {
                    TableroAjedrez[i, c] = simboloCasilla;
                }
            }
            TableroAjedrez[posH, posV] = simboloMovida;
        }


    }
}
