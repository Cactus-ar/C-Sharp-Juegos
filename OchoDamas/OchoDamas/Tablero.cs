using System;
using System.Collections.Generic;
using System.Text;

namespace OchoDamas
{
    public class Tablero
    {
        public const char CaracterTablero = '░';
        public const char CaracterDama = 'D';
        public char[,] tablero;

        public Tablero()
        {
            tablero = new char[8, 8];
        }

        public void MostrarTablero()
        {
            Console.WriteLine("╔════════╗");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("║");
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j] != CaracterTablero)
                    {
                        Console.Write(tablero[i, j]);
                    }else
                    {
                        if (i%2 == 0) //fila par
                        {
                            if(j%2 == 0) //columna par
                                Console.Write(" ");
                            else
                                Console.Write("░");

                        }else
                        {
                            if (j % 2 != 0) //columna impar
                                Console.Write(" ");
                            else
                                Console.Write("░");
                        }
                    }
                        


                }
                Console.WriteLine("║");
                
                
            }
            Console.WriteLine("╚════════╝");
        }

        public void Init()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tablero[i, j] = CaracterTablero;

                }

            }
        }
    }
}
