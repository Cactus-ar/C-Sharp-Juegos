using System;
using System.Collections.Generic;

namespace Generala
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            do
            {
                Pantallas.PantallaInicial();
                int jugadores = Pantallas.SeleccionarOpcion();

                if (jugadores == -1)
                    salir = true;
                else
                    salir = Juego.JuegoNuevo(jugadores);

            } while (!salir);
            


        }
    }

    class Jugador
    {
        public int JugadorNumero { get; set; }
        public string Nombre { get; set; }
        public int PuntajeTotal { get; set; }
        public int AlUno { get; set; }
        public int AlDos { get; set; }
        public int AlTres { get; set; }
        public int AlCuatro { get; set; }
        public int AlCinco { get; set; }
        public int AlSeis { get; set; }
        public int Full { get; set; }
        public int Poker { get; set; }
        public int Escalera { get; set; }
        public int Generala { get; set; }
        public int GeneralaDoble { get; set; }
    }

    class Juego
    {
        enum Valores
        {
            Uno = 1,
            Dos = 2,
            Tres = 3,
            Cuatro = 4,
            Cicnco = 5,
            Seis = 6,
            Generala = 60,
            Poker = 45,
            Full = 35,
            Escalera = 25
        }

        private static List<Jugador> crearJugadores(int numero)
        {
            List<Jugador> NuevaPartida = new List<Jugador>();

            for (int i = 1; i < numero+1; i++)
            {
                Jugador nuevo = new Jugador
                {
                    JugadorNumero = i,
                    Nombre = $"Jugador {i}",
                    PuntajeTotal = 0,
                    AlUno = 0,
                    AlDos = 0,
                    AlTres = 0,
                    AlCuatro = 2,
                    AlCinco = 05,
                    AlSeis = 30,
                    Full = 35,
                    Poker = 45,
                    Escalera = 55,
                    Generala = 65,
                    GeneralaDoble = 75,
                };
                NuevaPartida.Add(nuevo);
            }
            return NuevaPartida;
        }

        private static int[] lanzar(int cantidadDeDados)
        {
            int[] dados = new int[cantidadDeDados];
            Random rnd = new Random();

            for (int i = 0; i < cantidadDeDados; i++)
            {
                dados[i] = rnd.Next(1, 6);
            }

            return dados;
        }

        public static bool JuegoNuevo(int jugadores)
        {
            
            List<Jugador> Jugadores = crearJugadores(jugadores);

            //--comenzar

            var lanzamiento = lanzar(2);


            Pantallas.Dados(3, "Jugador1", lanzamiento);
            Pantallas.Planilla(Jugadores);

            //--comenzar el juego
            do
            {
                

            } while (Finalizo(Jugadores));

            return false;

        }


        public static bool Finalizo(List<Jugador> jugadores)
        {
            //calcular si quedan algun movimiento
            bool uno = false;
            bool dos = false;
            bool tres = false;
            bool cuatro = false;
            bool cinco = false;
            bool seis = false;
            bool escalera = false;
            bool full = false;
            bool poker = false;
            bool generala = false;
            bool servida = false;

            foreach (Jugador jugador in jugadores) //si alguno es 0 todavia quedan jugadas, -1 es tachada o el valor
            {
                uno = (jugador.AlUno != 0) ? true : false;
                dos = (jugador.AlUno != 0) ? true : false;
                tres = (jugador.AlUno != 0) ? true : false;
                cuatro = (jugador.AlUno != 0) ? true : false;
                cinco = (jugador.AlUno != 0) ? true : false;
                seis = (jugador.AlUno != 0) ? true : false;
                escalera = (jugador.AlUno != 0) ? true : false;
                full = (jugador.AlUno != 0) ? true : false;
                poker = (jugador.AlUno != 0) ? true : false;
                generala = (jugador.AlUno != 0) ? true : false;
                servida = (jugador.AlUno != 0) ? true : false;
            }

            return (uno && dos && tres && cuatro && cinco && seis && escalera && full && poker && generala && servida) ? true : false;
        }
    }

    class Pantallas
    {
       
            //  ---
            // |* *|
            // | * |
            // |* *|
            //  ---

        
        public static void Dados(int intento, string Jugador, int[]dados)
        {
            int cantidad = dados.Length;

            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"Turno de {Jugador}, intento {intento}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Dado {i + 1}: {dados[i]},");
            }
            //Console.WriteLine($"Dado 1: {dados[0]}, Dado 2: {dados[1]}, Dado 3: {dados[2]}, Dado 4: {dados[3]}, Dado 5: {dados[4]}");
            Console.WriteLine();

        }

        public static void Planilla(List<Jugador> jugadores)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Jugador   | 1 |  2  |  3  |  4  |  5  |  6  |Esca|Full|Poker|Gene|Doble|  Total ");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (Jugador jugador in jugadores)
            {
                Console.WriteLine($"{jugador.Nombre} | {jugador.AlUno} |  {jugador.AlDos.ToString("D2")} |  {jugador.AlTres.ToString("D2")} " +
                    $"|  {jugador.AlCuatro.ToString("D2")} |  {jugador.AlCinco.ToString("D2")} |  {jugador.AlSeis.ToString("D2")} " +
                    $"| {jugador.Escalera.ToString("D2")} | {jugador.Full.ToString("D2")} |  {jugador.Poker.ToString("D2")} | {jugador.Generala.ToString("D2")} " +
                    $"|  {jugador.GeneralaDoble.ToString("D2")} |   {jugador.PuntajeTotal.ToString("D3")}   ");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

        }

        public static void PantallaInicial()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("GENERALA v1.0");
            Console.WriteLine("-----------------------");
        }

        public static int SeleccionarOpcion()
        {
            do
            {
                Console.Write("Cantidad de Jugadores(1-4) ó X para Salir: ");
                var ingreso = Console.ReadLine();

                switch (ingreso)
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    case "3":
                        return 3;
                    case "4":
                        return 4;
                    case "x":
                    case "X":
                        return -1;
                    default:
                        Console.WriteLine("Opción Incorrecta");
                        break;
                }

            } while (true);

            
        }
    }


}
