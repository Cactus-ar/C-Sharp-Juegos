using System;
using System.Collections.Generic;
using System.Text;

namespace CarreraAnimales
{
    public class Pista
    {
        public const int LargoDeLaPista = 20;
        public const int CantidadDeCorredores = 5;

        public string[,] Carriles { get; set; }

        public Pista()
        {
            Carriles = new string[LargoDeLaPista + 1, CantidadDeCorredores]; // +1 para aggregar la llegada al largo
        }

        public void DibujarLaPista()
        {
            Console.WriteLine();
            for (int i = 0; i <= LargoDeLaPista; i++)
            {
                if (i<10)
                {
                    Console.Write(" " + i + "  | ");
                }
                else
                {
                    Console.Write(i + "  | ");
                }
                

                for (int c = 0; c < CantidadDeCorredores; c++)
                {
                    if (Carriles[i,c] == null)
                    {
                        Console.Write("  | ");
                    }else
                    {
                        Console.Write(Carriles[i,c] + " | ");
                    }
                    
                }
                Console.WriteLine();
            }
            
        }
        public void PosicionCorredor(Corredor corredor)
        {
            Carriles[corredor.PosicionOriginal, corredor.Carril] = null; //antes de actualizar la posicion, borrar la actual
            Carriles[corredor.PosicionActual, corredor.Carril] = corredor.SimboloDelCorredor;
        }

    }
}
