using System;

namespace Dados
{
    class Program
    {
        static void Main(string[] args)
        {
            var tirada = new Random();
            char entrada = 'a';

            do
            {
                
                Console.WriteLine("Presione una tecla para lanzar el dado o Z para salir");
                Console.WriteLine("-----------------------------------------------------");
                entrada = Console.ReadKey().KeyChar;
                Console.WriteLine();


                int lanza = tirada.Next(1, 7);

                switch (lanza)
                {
                    case 1:
                        Dado.Cara1();
                        break;

                    case 2:
                        Dado.Cara2();
                        break;

                    case 3:
                        Dado.Cara3();
                        break;

                    case 4:
                        Dado.Cara4();
                        break;

                    case 5:
                        Dado.Cara5();
                        break;

                    case 6:
                        Dado.Cara6();
                        break;

                    default:
                        break;
                }


            } while (entrada != 'Z');



        }
    }

    class Dado
    {
        public static void Cara1()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("|       |");
            Console.WriteLine("|   *   |");
            Console.WriteLine("|       |");
            Console.WriteLine("+-------+");
        }
        public static void Cara2()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("|  *    |");
            Console.WriteLine("|       |");
            Console.WriteLine("|    *  |");
            Console.WriteLine("+-------+");
        }
        public static void Cara3()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("|  *    |");
            Console.WriteLine("|   *   |");
            Console.WriteLine("|    *  |");
            Console.WriteLine("+-------+");
        }
        public static void Cara4()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("| *   * |");
            Console.WriteLine("|       |");
            Console.WriteLine("| *   * |");
            Console.WriteLine("+-------+");
        }
        public static void Cara5()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("| *   * |");
            Console.WriteLine("|   *   |");
            Console.WriteLine("| *   * |");
            Console.WriteLine("+-------+");
        }
        public static void Cara6()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("| *   * |");
            Console.WriteLine("| *   * |");
            Console.WriteLine("| *   * |");
            Console.WriteLine("+-------+");
        }
    }
}
