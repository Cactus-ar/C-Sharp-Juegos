using System;

namespace SokobanConsola
{
    class Program
    {
       enum Direccion
        {
            Arriba,
            Abajo,
            Izquierda,
            Derecha
        };

        enum Simbolos
        {
            Jugador = '@',
            Pared = '#',
            Caja = '$',
            Piso = ' ',
            Objetivo = '.',
            CajaColocada = '*'
        };


        struct Jugador
        {
            public int posX;
            public int posY;
        }


        Simbolos[,] mapa;
        Jugador[] posJugador;
        Direccion direccion;


        public static ConsoleColor DefFore { get; set; }
        public static ConsoleColor DefBack { get; set; }
        public static ConsoleColor ColorFrente { get; set; }
        public static ConsoleColor ColorFondo { get; set; }
        

        static void Main(string[] args)
        {
            
            bool salir = false;
            int nivel = 0;

            //Guardar los colores de la consola por defecto que usa el usuario
            DefFore = Console.ForegroundColor;
            DefBack = Console.BackgroundColor;
            ColorFrente = ConsoleColor.Green;   //iniciar en verde sobre negro
            ColorFondo = ConsoleColor.Black;

          
            do
            {

                int opcion = MenuInicial(nivel);

                switch (opcion)
                {
                    case 1:
                        
                        Nivel NivelJugando = new Nivel(1)
                        {
                            NivelIniciado = true,
                            
                        };
                        PantallaJuego();
                        break;
                    case 2:
                        nivel = SeleccionNivel(nivel);
                        //seleccinar nivel
                        break;
                    case 3:
                        SeleccionOpciones();
                        //opciones
                        break;
                    case 4:
                        salir = true;
                        break;

                    default:
                        break;
                }


            } while (!salir);

            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\tHasta Pronto!");
            Console.WriteLine("-----------------------------");
            Console.BackgroundColor = DefBack; //restaurar valores de color originales de consola
            Console.ForegroundColor = DefFore;


        }

        static int MenuInicial(int nivel)
        {
            Console.Clear();
            Console.BackgroundColor = ColorFondo;
            Console.ForegroundColor = ColorFrente;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("            S O K O B A N");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Nivel Actual: " + nivel);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("\t1.- Nuevo Juego");
            Console.WriteLine("\t2.- Seleccinar Nivel");
            Console.WriteLine("\t3.- Opciones");
            Console.WriteLine("\t4.- Salir");
            Console.WriteLine("---------------------------------------");
            Console.Write("Ingrese una Opcion -> ");
            int opcion;
            try
            {
                opcion = (int)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

                return 0;
            }

            return opcion;

        }

        static int SeleccionNivel(int nivel)
        {
            Console.Clear();
            Console.BackgroundColor = ColorFondo;
            Console.ForegroundColor = ColorFrente;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("            S O K O B A N");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Nivel Actual: " + nivel);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("  Ingrese el Numero de Nivel (1-90)");
            Console.WriteLine("  o presione 0 para volver");
            Console.WriteLine("---------------------------------------");
            Console.Write("Ingrese una Opcion -> ");
            int opcion;
            try
            {
                opcion = (int)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

                return 0;
            }
            return opcion;
        }

        static void SeleccionOpciones()
        {
            var opcion = 0;
            Console.Clear();
            Console.BackgroundColor = ColorFondo;
            Console.ForegroundColor = ColorFrente;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("            S O K O B A N");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("  Seleccion de Colores");
            Console.WriteLine("  --------------------");
            Console.WriteLine(" 1.- Colores Originales de Consola");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 2.- Blanco sobre Negro");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" 3.- Verde sobre Negro");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" 4.- Cyan sobre Negro");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" 5.- Magenta sobre Negro");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------");
            Console.Write("Ingrese una Opcion -> ");
            try
            {
                opcion = (int)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            switch (opcion)
            {
                case 1:
                    ColorFondo = DefBack;
                    ColorFrente = DefFore;
                    break;
                case 2:
                    ColorFondo = ConsoleColor.Black;
                    ColorFrente = ConsoleColor.White;
                    break;
                case 3:
                    ColorFondo = ConsoleColor.Black;
                    ColorFrente = ConsoleColor.Green;
                    break;
                case 4:
                    ColorFondo = ConsoleColor.Black;
                    ColorFrente = ConsoleColor.Cyan;
                    break;
                case 5:
                    ColorFondo = ConsoleColor.Black;
                    ColorFrente = ConsoleColor.Magenta;
                    break;
            }
            return;
        }

        static void PantallaJuego()
        {

            ConsoleKeyInfo tecla;
            int pasos = 0;
            Console.BackgroundColor = ColorFondo;
            Console.ForegroundColor = ColorFrente;
            GenerarMapa();

            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("             S O K O B A N");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine(" Nivel: " + NivelJugando.Id + "\tPasos: " + pasos);
                Console.WriteLine("-----------------------------------------");
                foreach (var item in NivelJugando.Mapa)
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" Flechas para moverse, 0 para salir");
                Console.WriteLine("------------------------------------------");

                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {

                    case ConsoleKey.DownArrow:
                        pasos++;
                        break;

                    case ConsoleKey.LeftArrow:
                        pasos++;
                        break;

                    case ConsoleKey.RightArrow:
                        pasos++;
                        break;

                    case ConsoleKey.UpArrow:
                        pasos++;
                        break;

                }



            } while (tecla.Key != ConsoleKey.D0);
            return;
        }

        static void GenerarMapa()
        {
            for (int i = 0; i < NivelJugando.Ancho; i++)
            {
                for (int j = 0; j < NivelJugando.Alto; j++)
                {
                    //                    Console.WriteLine("\t" + nivel.DibujoNivel.Item(i).InnerText.ToString());
                    NivelJugando.Mapa[i, j] = Convert.ToChar(NivelJugando.DibujoNivel.Item(i).InnerText.Substring(j, 1));

                }

            }
        }

    }
    
}
