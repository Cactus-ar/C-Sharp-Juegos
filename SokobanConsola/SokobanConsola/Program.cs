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
            Derecha,
            Quieto
        };

      

       struct Jugador
        {
            public int posX;
            public int posY;
        }

        private static Direccion direccion;
        private static Jugador posJugador;
        private static int nivel = 0;
        private static int opcion;
        private static ConsoleColor DefFore { get; set; }
        private static ConsoleColor DefBack { get; set; }
        private static ConsoleColor ColorFrente { get; set; }
        private static ConsoleColor ColorFondo { get; set; }
        public static Nivel NivelJugando { get; private set; }
        private static char[,] Mapa;
        

        static void Main(string[] args)
        {
            
            //Guardar los colores de la consola por defecto que usa el usuario
            DefFore = Console.ForegroundColor;
            DefBack = Console.BackgroundColor;
            ColorFrente = ConsoleColor.Green;   //iniciar en verde sobre negro
            ColorFondo = ConsoleColor.Black;
            posJugador.posX = 0;
            posJugador.posY = 0;
            direccion = Direccion.Quieto;
            


            bool salir = false;
            
            do
            {
                opcion = MenuInicial(nivel);

                switch (opcion)
                {
                    case 1:

                        NivelJugando = new Nivel(1);
                        Mapa[NivelJugando.Alto, NivelJugando.Ancho] = new char();
                        GenerarMapa(Mapa);
                        BuscarJugador();
                        PantallaJuego();
                        
                        break;
                    case 2:
                        nivel = SeleccionNivel(nivel);
                        NivelJugando = new Nivel(nivel);
                        PantallaJuego();
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
            int seleccion;
            try
            {
                seleccion = (int)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return 0;
            }

            return seleccion;

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
            //GenerarMapa();

            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("             S O K O B A N");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine(" Nivel: " + NivelJugando.Id + "\tPasos: " + pasos);
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < NivelJugando.Alto; i++)
                {
                    for (int j = 0; j < NivelJugando.Ancho; j++)
                    {
                        Console.Write(Mapa[i,j]);
                    }
                    Console.Write("\n");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" Flechas para moverse, 0 para salir");
                Console.WriteLine("------------------------------------------");

                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {

                    case ConsoleKey.DownArrow:
                        direccion = Direccion.Abajo;
                        pasos++;
                        break;

                    case ConsoleKey.LeftArrow:
                        direccion = Direccion.Izquierda;
                        pasos++;
                        break;

                    case ConsoleKey.RightArrow:
                        direccion = Direccion.Derecha;
                        pasos++;
                        break;

                    case ConsoleKey.UpArrow:
                        direccion = Direccion.Arriba;
                        pasos++;
                        break;

                }



            } while (tecla.Key != ConsoleKey.D0);
            return;
        }

        static void BuscarJugador()
        {

            for (int i = 0; i < NivelJugando.DibujoNivel.Count; i++) //Cantidad de Lineas
            {
                string linea = NivelJugando.DibujoNivel.Item(i).InnerText.ToString();
                int largo = linea.Length;

                for (int j = 0; j < largo; j++)
                {
                    char busqueda = Convert.ToChar(linea.Substring(j, 1));
                    if (busqueda == '@')
                    {
                        posJugador.posX = i;
                        posJugador.posY = j;
                        return;

                    }

                }

            }

        }

        static void GenerarMapa(char[,] Mapa)
        {
            for (int i = 0; i < NivelJugando.DibujoNivel.Count; i++) //Cantidad de Lineas
            {
                string linea = NivelJugando.DibujoNivel.Item(i).InnerText.ToString();
                int largo = linea.Length;

                for (int j = 0; j < largo; j++)
                {
                    Mapa[i,j] = Convert.ToChar(linea.Substring(j, 1));

                }

            }
            return;
        }

    }
    
}
