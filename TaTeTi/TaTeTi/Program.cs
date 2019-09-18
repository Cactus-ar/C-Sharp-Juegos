using System;
using System.Collections.Generic;

/*
*      X | 0 | X
*      --+---+--
*      0 | X | 0
*      --+---+--
*      X | 0 | 0
*      
*/

namespace TaTeTi
{
    public class Pantallas
    {
        public void DibujarTablero(List<Jugada> movidas)
        {
            
            Console.WriteLine("\t ----------------------------------------");
            Console.WriteLine("\t   {0}  |  {1}  |  {2} \t {3}  {4}  {5}", movidas[0].Jugador, movidas[1].Jugador, movidas[2].Jugador, movidas[0].Posicion, movidas[1].Posicion, movidas[2].Posicion);
            Console.WriteLine("\t -----+-----+-----");
            Console.WriteLine("\t   {0}  |  {1}  |  {2} \t {3}  {4}  {5}", movidas[3].Jugador, movidas[4].Jugador, movidas[5].Jugador, movidas[3].Posicion, movidas[4].Posicion, movidas[5].Posicion);
            Console.WriteLine("\t -----+-----+-----");
            Console.WriteLine("\t   {0}  |  {1}  |  {2} \t {3}  {4}  {5}", movidas[6].Jugador, movidas[7].Jugador, movidas[8].Jugador, movidas[6].Posicion, movidas[7].Posicion, movidas[8].Posicion);
            Console.WriteLine("\t ----------------------------------------");
            Console.Write("\t Movidas Disponibles:");
            foreach (var item in movidas)
            {
                Console.Write(" " + item.Posicion.ToString());
            }
            Console.WriteLine();
            return;

        }

        public void MensajeInicial()
        {
            Console.Clear();
            Console.WriteLine("\t   Bienvenido a Ta - Te - Ti");
            Console.WriteLine("\t   version..multiplayer :p");
            Console.WriteLine("\t   -------------------------");
            Console.WriteLine("\t   1.- Juego Nuevo");
            Console.WriteLine("\t   2.- Puntajes");
            Console.WriteLine("\t   3.- Salir");
            Console.WriteLine("\t   -------------------------");
            return;
        }

        public void Salida()
        {
            Console.Clear();
            Console.WriteLine("\t   Gracias por Jugar!!");
            Console.WriteLine("\t   Nos Vemos.-");
            Console.WriteLine("\t   -------------------------");
            return;

        }

        public void Encabezado(Jugador jugador1, Jugador jugador2, bool turno)
        {
            string nombre;

            if (turno)
                nombre = jugador1.Nombre.ToString();
            else
                nombre = jugador2.Nombre.ToString();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t ----------------------------------------");
            Console.WriteLine("\t {0} -> {2}  | {1} -> {3}", jugador1.Nombre, jugador2.Nombre, jugador1.Simbolo, jugador2.Simbolo);
            Console.WriteLine();
            Console.WriteLine("\t Turno de: {0}          Teclas:", nombre);
            return;
        }

        public void HayEmpate()
        {
            Console.WriteLine("\t ----------------------------------------");
            Console.WriteLine("\t             E M P A T E");
            Console.WriteLine("\t ----------------------------------------");
        }

        public void HayGanador(Jugador jugador1, Jugador jugador2, char ganador)
        {
            string jugador;

            if (ganador == 'X')
                jugador = jugador1.Nombre;
            else
                jugador = jugador2.Nombre;


            Console.WriteLine("\t ----------------------------------------");
            Console.WriteLine("\t Ganador : {0}", jugador.ToString());
            Console.WriteLine("\t ----------------------------------------");
        }

    }

    public class Jugador
    {
        public string Nombre { get; set; }
        public int Puntaje { get; set; }
        public char Simbolo { get; set; }

      
    }

    public class Jugada
    {
        public string Posicion { get; set; }
        public string Jugador { get; set; }

    }


    class Program
    {
        

        static void Main(string[] args)
        {
            
            Pantallas pantallas = new Pantallas();
            Jugador jugador_1 = new Jugador();
            Jugador jugador_2 = new Jugador();

            
            List<Jugada> movidas = new List<Jugada>();

            for (int i = 1; i < 10; i++)
            {
                movidas.Add(new Jugada { Posicion = i.ToString(), Jugador = " "});
            }

            var opcion = 0;
            bool SigueJugando = true;
            bool turno = true;

            do
            {
                pantallas.MensajeInicial();
                Console.Write("\t Ingrese una opcion (1-3) -> ");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {

                }

                switch (opcion)
                {
                    case 1:
                        Inicializar(jugador_1, jugador_2, ref turno);
                        ComenzarJuego(jugador_1, jugador_2, pantallas, movidas, turno);
                        break;
                    case 2:
                        TablaDePuntaje(jugador_1, jugador_2);
                        break;
                    case 3:
                        SigueJugando = false;
                        break;

                }

            } while (SigueJugando);

            pantallas.Salida();
        }

        private static void TablaDePuntaje(Jugador jugador1, Jugador jugador2)
        {
            Console.Clear();
            Console.WriteLine("\t-------------------");
            Console.WriteLine("\tTabla de Posiciones");
            Console.WriteLine("\t-------------------");
            Console.WriteLine();
            Console.WriteLine("\t{0}:\t{1} Puntos", jugador1.Nombre, jugador1.Puntaje);
            Console.WriteLine("\t{0}:\t{1} Puntos", jugador2.Nombre, jugador2.Puntaje);
            Console.WriteLine();
            Console.WriteLine("\t-------------------");
            Console.WriteLine("\tPresione una Tecla");
            Console.WriteLine("\t-------------------");

            Console.ReadKey();
        }

        private static void Inicializar(Jugador jugador_1, Jugador jugador_2,ref bool turno)
        {
            Random quienComienza = new Random();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tJugador 1:");
            Console.WriteLine("\t----------");
            Console.Write("\tNombre: ");

            jugador_1.Nombre = Console.ReadLine();
            jugador_1.Simbolo = 'X';
            jugador_1.Puntaje = 0;
            Console.WriteLine("\t----------");
            Console.WriteLine("\t{0} tiene asignado el simbolo {1} para jugar", jugador_1.Nombre, jugador_1.Simbolo);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("\tJugador 2:");
            Console.WriteLine("\t----------");
            Console.Write("\tNombre: ");
            jugador_2.Nombre = Console.ReadLine();
            jugador_2.Simbolo = '0';
            jugador_2.Puntaje = 0;
            Console.WriteLine("\t----------");
            Console.WriteLine("\t{0} tiene asignado el simbolo {1} para jugar", jugador_2.Nombre, jugador_2.Simbolo);
            Console.WriteLine();
            Console.WriteLine("\tPresiona una tecla para la eleccion del jugador que inicia la partida");
            Console.ReadKey();

            int seleccion = quienComienza.Next(10);

            if (seleccion % 2 == 0)
            { 
                Console.WriteLine("\tComienza el Juego: {0}", jugador_1.Nombre);
                turno = true;
            }
            else
            {
                Console.WriteLine("\tComienza el Juego: {0}",jugador_2.Nombre);
                turno = false;
            }
            Console.WriteLine("\tPresiona una tecla para comenzar");
            Console.ReadKey();
            return;



        }

        private static void ComenzarJuego(Jugador jugador_1, Jugador jugador_2, Pantallas pantallas, List<Jugada>movidas, bool turno)
        {
            int estado = -1; //estado 5 juego en progreso
            char ganador;
            bool sinMovidas = false;
            ConsoleKeyInfo tecla;

            do
            {
                pantallas.Encabezado(jugador_1, jugador_2, turno);
                pantallas.DibujarTablero(movidas);
                tecla = Console.ReadKey();

                try
                {
                    switch (tecla.Key)
                    {
                        case ConsoleKey.Backspace:  //retroceso vuelve al menu
                            sinMovidas = true;
                            break;

                        case ConsoleKey.D1:
                            if (movidas[0].Posicion == "1")
                            {
                                    movidas[0].Posicion = " ";
                                if (turno)
                                {
                                    movidas[0].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[0].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            
                            break;

                        case ConsoleKey.D2:
                            if (movidas[1].Posicion == "2")
                            {
                                movidas[1].Posicion = " ";
                                if (turno)
                                {
                                    movidas[1].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[1].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.D3:
                            if (movidas[2].Posicion == "3")
                            {
                                movidas[2].Posicion = " ";
                                if (turno)
                                {
                                    movidas[2].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[2].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }

                            break;

                        case ConsoleKey.D4:
                            if (movidas[3].Posicion == "4")
                            {
                                movidas[3].Posicion = " ";
                                if (turno)
                                {
                                    movidas[3].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[3].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.D5:
                            if (movidas[4].Posicion == "5")
                            {
                                movidas[4].Posicion = " ";
                                if (turno)
                                {
                                    movidas[4].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[4].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.D6:
                            if (movidas[5].Posicion == "6")
                            {
                                movidas[5].Posicion = " ";
                                if (turno)
                                {
                                    movidas[5].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[5].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.D7:
                            if (movidas[6].Posicion == "7")
                            {
                                movidas[6].Posicion = " ";
                                if (turno)
                                {
                                    movidas[6].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[6].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.D8:
                            if (movidas[7].Posicion == "8")
                            {
                                movidas[7].Posicion = " ";
                                if (turno)
                                {
                                    movidas[7].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[7].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.D9:
                            if (movidas[8].Posicion == "9")
                            {
                                movidas[8].Posicion = " ";
                                if (turno)
                                {
                                    movidas[8].Jugador = "X";
                                    turno = false;
                                }
                                else
                                {
                                    movidas[8].Jugador = "0";
                                    turno = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t Casilla ya Jugada!");
                                Console.ReadKey();
                            }
                            break;

                        default:
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("\t Movida NO disponible");
                    Console.ReadKey();
                }

                //analizar jugadas
                estado = ChequearGanador(ref sinMovidas, movidas);
                switch (estado)
                {
                    case -1: //Juego sigue normal
                        break;
                    case 0: //Hay empate
                        pantallas.HayEmpate();
                        sinMovidas = true;
                        break;
                    case 1: //Gano X
                        ganador = 'X';
                        pantallas.HayGanador(jugador_1, jugador_2, ganador);
                        jugador_1.Puntaje++;
                        sinMovidas = true;
                        break;
                    case 2: //Gano X
                        ganador = '0';
                        pantallas.HayGanador(jugador_1, jugador_2, ganador);
                        jugador_2.Puntaje++;
                        sinMovidas = true;
                        break;

                }

            } while (!sinMovidas);

            Console.WriteLine("\tVolver al Menu, Presione una Tecla");
            Console.ReadKey();
        }

        private static int ChequearGanador(ref bool sinMovidas, List<Jugada>movidas)
        {
            char ganador;
            //basicamente chequear por cada posibilidad de que uno de los jugadores ha ganado
            //devuelve -1 si no hay ganador pero se sigue jugando
            //devuelve  0 si es empate
            //devuelve  1 si gano X
            //devuelve  2 si gano 0

            //Chequear Horizontal (012 + 345 + 678)
            if (movidas[0].Jugador != " " && movidas[1].Jugador != " " && movidas[1].Jugador != " " &&
                movidas[0].Jugador == movidas[1].Jugador && movidas[1].Jugador == movidas[2].Jugador)
            {
                ganador = Convert.ToChar(movidas[0].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;

            }
            else if(movidas[3].Jugador != " " && movidas[4].Jugador != " " && movidas[5].Jugador != " " &&
                movidas[3].Jugador == movidas[4].Jugador && movidas[4].Jugador == movidas[5].Jugador)
            {
                ganador = Convert.ToChar(movidas[3].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }
            else if(movidas[6].Jugador != " " && movidas[7].Jugador != " " && movidas[8].Jugador != " " &&
                movidas[6].Jugador == movidas[7].Jugador && movidas[7].Jugador == movidas[8].Jugador)
            {
                ganador = Convert.ToChar(movidas[6].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }

            //Chequear Vertical (036 + 147 + 258)
            else if (movidas[0].Jugador != " " && movidas[3].Jugador != " " && movidas[6].Jugador != " " &&
                movidas[0].Jugador == movidas[3].Jugador && movidas[3].Jugador == movidas[6].Jugador)
            {
                ganador = Convert.ToChar(movidas[0].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }
            else if (movidas[1].Jugador != " " && movidas[4].Jugador != " " && movidas[7].Jugador != " " &&
                movidas[1].Jugador == movidas[4].Jugador && movidas[4].Jugador == movidas[7].Jugador)
            {
                ganador = Convert.ToChar(movidas[1].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }
            else if (movidas[2].Jugador != " " && movidas[5].Jugador != " " && movidas[8].Jugador != " " &&
                movidas[2].Jugador == movidas[5].Jugador && movidas[5].Jugador == movidas[8].Jugador)
            {
                ganador = Convert.ToChar(movidas[2].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }

            //Chequear Cruzadas (048 + 246)
            else if (movidas[0].Jugador != " " && movidas[4].Jugador != " " && movidas[8].Jugador != " " &&
                movidas[0].Jugador == movidas[4].Jugador && movidas[4].Jugador == movidas[8].Jugador)
            {
                ganador = Convert.ToChar(movidas[0].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }
            else if (movidas[2].Jugador != " " && movidas[4].Jugador != " " && movidas[6].Jugador != " " &&
                movidas[2].Jugador == movidas[4].Jugador && movidas[4].Jugador == movidas[6].Jugador)
            {
                ganador = Convert.ToChar(movidas[2].Jugador);
                if (ganador == 'X')
                    return 1;
                else
                    return 0;
            }
            //Chequear por un Empate
            else if (movidas[0].Posicion == " " && movidas[1].Posicion == " " && movidas[2].Posicion == " " && movidas[3].Posicion == " " &&
                movidas[4].Posicion == " " && movidas[5].Posicion == " " && movidas[6].Posicion == " " && movidas[7].Posicion == " " && movidas[8].Posicion == " ")
            {
                //Hay EMpate
                return 0;

            }else
            {
                //Se sigue jugando
                return -1;
            }


        }
    }
}
