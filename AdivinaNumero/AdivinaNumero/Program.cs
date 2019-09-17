using System;

namespace AdivinaNumero
{
    class Program
    {
        static void Main(string[] args)
        {
            bool seguir = false;
            var random = new Random();


            do
            {
                var incognita = random.Next(1, 10);
                var intentos = 0;

                do
                {
                    Console.Write("Adivine el numero (1 al 9) -> ");
                    

                    try
                    {
                        var adivina = Convert.ToInt16(Console.ReadLine());
                        if (adivina == incognita)
                        {
                            Console.WriteLine("Bien, Adivino");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("MAL...casi");
                            intentos++;
                        }
                    }
                    catch (Exception)
                    {

                        
                    }

                   

                } while (intentos < 3);


                Console.WriteLine("El numero era {0}", incognita);
                Console.Write("De nuevo? (S/N) :");
                char denuevo = Console.ReadKey().KeyChar;

                if (denuevo != 's')
                {
                    seguir = true;
                }

                Console.Clear();

            } while (!seguir);

            

        }


    }
}
