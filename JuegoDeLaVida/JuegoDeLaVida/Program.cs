using System;
using System.Threading;

namespace JuegoDeLaVida
{
    class Program
    {
        /*
         * para una explicacion de las reglas y que es
         * https://es.wikipedia.org/wiki/Juego_de_la_vida
         * 
         */

        static int Alto;
        static int Ancho;
        static int GeneracionesMaximas = 200;
        static bool[,] Celulas;

        static void Inicializar(int alto, int ancho)
        {
            Random aleatorio = new Random();
            int numero;

            Alto = alto;
            Ancho = ancho;
            Celulas = new bool[Alto, Ancho];

            for (int i = 0; i < Alto; i++)
            {
                for (int j = 0; j < Ancho; j++)
                {
                    numero = aleatorio.Next(2);
                    if (numero == 0)
                        Celulas[i, j] = false;
                    else
                        Celulas[i, j] = true;
                }
            }



        }


        static void DibujarMundo()
        {
            for (int i = 0; i < Alto; i++)
            {
                for (int j = 0; j < Ancho; j++)
                {
                    if(Celulas[i,j])
                        Console.Write("░░");
                    else
                        Console.Write("  ");

                    if(j == Alto -1)
                        Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        static void Crecer()
        {
            for (int i = 0; i < Alto; i++)
            {
                for (int j = 0; j < Ancho; j++)
                {
                    int VecinosVivos = LosVecinos(i, j);

                    if (Celulas[i, j])
                    {
                        if (VecinosVivos < 2)
                        {
                            Celulas[i, j] = false;
                        }

                        if (VecinosVivos > 3)
                        {
                            Celulas[i, j] = false;
                        }
                    }
                    else
                    {
                        if (VecinosVivos == 3)
                        {
                            Celulas[i, j] = true;
                        }
                    }
                }
            }
        }

        static int LosVecinos(int x, int y)
        {
            int VecinosVivos = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Alto || j >= Ancho)))
                    {
                        if (!((i == x) && (j == y)))
                        {
                            if (Celulas[i, j] == true) VecinosVivos++;
                        }
                    }
                }
            }
            return VecinosVivos;
        }


        static void Main(string[] args)
        {
            Inicializar(20, 20);
            int generacion = 0;
            while(generacion++ < GeneracionesMaximas)
            {
                Console.WriteLine($"Generacion: {generacion}");
                DibujarMundo();
                Crecer();
                Thread.Sleep(100);
                
            }
            
        }
    }
}
