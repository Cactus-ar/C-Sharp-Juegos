using System;
using System.Text;

namespace BkackJack
{
    public class Baraja
    {
        public string Palo { get; set; }
        public int Valor { get; set; }
        
                
        public Baraja(int palo, int valor)
        {
            Valor = valor;

            switch (palo) 
            {
                case 1: 
                    Palo = " de Trebol";
                    break;
                case 2:
                    Palo = " de Diamante";
                    break;
                case 3:
                    Palo = " de Corazones";
                    break;
                case 4: 
                    Palo = " de Espadas";
                    break;
            }

            
        }
    }

    public class Pantallas
    {
        public void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("\t╔═════════════════════════════╗");
            Console.WriteLine("\t║       BLACKJACK v1.0        ║░");
            Console.WriteLine("\t║                             ║░");
            Console.WriteLine("\t║       1.-Juego Nuevo        ║░");
            Console.WriteLine("\t║       2.-Instrucciones      ║░");
            Console.WriteLine("\t║       3.-Salir              ║░");
            Console.WriteLine("\t╚═════════════════════════════╝░");

            //Console.WriteLine("\t▄▀══════π════▀■▄══════════════════╝░"); prueba de caracteres
            return;
        }

        public void Juego(Jugador jugador, Jugador banca, int puntero)
        {
            Console.Clear();
            Console.WriteLine("\t════════════════════════════════════════");
            Console.WriteLine("\tNombre: {0}", jugador.nombre);
            Console.WriteLine("\t════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("\tJugador:\t\tLa Banca:");
            var jugador_valor = 0;

            for (int i = 0; i < puntero ; i++) //No existen mas entradas que el numero de cartas sacadas del mazo
            {
                try
                {
                    jugador_valor = jugador.mano[i].Valor;
                }
                catch (Exception)
                {

                    jugador_valor = 0;
                }
                
                if(jugador_valor != 0)
                {
                    string jugador_valor_cadena;

                    switch (jugador_valor)
                    {
                        case 1:
                            jugador_valor_cadena = "As";
                            break;
                        case 11:
                            jugador_valor_cadena = "J";
                            break;
                        case 12:
                            jugador_valor_cadena = "Q";
                            break;
                        case 13:
                            jugador_valor_cadena = "K";
                            break;
                        default:
                            jugador_valor_cadena = jugador_valor.ToString();
                            break;
                    }

                    Console.WriteLine("\t{0}{1}\t\t{2}{3}", jugador_valor_cadena, jugador.mano[0].Palo, banca.mano[0].Valor, banca.mano[0].Palo);
                }
                

            }
            
            Console.WriteLine("\t════════════════════════════════════════");
            Console.WriteLine("\t{0} Puntos\t\t{1} Puntos", jugador.puntos, banca.puntos);
            Console.WriteLine("\t════════════════════════════════════════");
            

        }



        public void Instrucciones()
        {
            Console.Clear();
            Console.WriteLine("\t╔════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║  INSTRUCCIONES:                                    ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t║  El blackjack, también llamado veintiuno,          ║░");
            Console.WriteLine("\t║  es un juego de cartas, propio de los casinos      ║░");
            Console.WriteLine("\t║  con una o más barajas inglesas de 52 cartas sin   ║░");
            Console.WriteLine("\t║  los comodines, que consiste en sumar un valor     ║░");
            Console.WriteLine("\t║  lo más próximo a 21 pero sin pasarse.             ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t╚════════════════════════════════════════════════════╝░");
            Console.WriteLine("\t Presione una tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\t╔════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║  INSTRUCCIONES:                                    ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t║  El crupier está sujeto a reglas fijas que le      ║░");
            Console.WriteLine("\t║  impiden tomar decisiones sobre el juego. Por      ║░");
            Console.WriteLine("\t║  ejemplo, está obligado a pedir carta siempre que  ║░");
            Console.WriteLine("\t║  su puntuación sume 16 o menos, y obligado a       ║░");
            Console.WriteLine("\t║  plantarse si suma 17 o más                        ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t╚════════════════════════════════════════════════════╝░");
            Console.WriteLine("\t Presione una tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\t╔════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║  INSTRUCCIONES:                                    ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t║  Las cartas numéricas suman su valor, las figuras  ║░");
            Console.WriteLine("\t║  suman 10 y el As vale 11 o 1, a elección del      ║░");
            Console.WriteLine("\t║  jugador. En el caso del crupier, los Ases valen   ║░");
            Console.WriteLine("\t║  11 mientras no se pase de 21, y 1 en caso         ║░");
            Console.WriteLine("\t║  contrario.                                        ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t╚════════════════════════════════════════════════════╝░");
            Console.WriteLine("\t Presione una tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\t╔════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║  INSTRUCCIONES:                                    ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t║  La mejor jugada es conseguir 21 con solo dos      ║░");
            Console.WriteLine("\t║  cartas, esto es con un As más carta de valor 10.  ║░");
            Console.WriteLine("\t║  Esta jugada se conoce como BlackJack o 21 natural ║░");
            Console.WriteLine("\t║  Un BlackJack gana sobre un 21 conseguido con      ║░");
            Console.WriteLine("\t║  más de dos cartas.                                ║░");
            Console.WriteLine("\t║                                                    ║░");
            Console.WriteLine("\t╚════════════════════════════════════════════════════╝░");
            Console.WriteLine("\t Presione una tecla");
            return;

        }
    }

    public class Jugador
    {
        public Baraja[] mano;
        public int puntos { get; set; }
        public int barajasEnLaMano { get; set; }
        public string nombre { get; set; }

        public Jugador()
        {
            mano = new Baraja[5];
            barajasEnLaMano = 0;
            puntos = 0;

        }

    }

    class Program
    {

        static int punteroDelMazo = 0;

        static Baraja[] generarMazo()
        {
            // Genera las 52 cartas del mazo

            Baraja[] mazo = new Baraja[52]; // el tamaño de un mazo estandard de 13 x 4
            int contar = 0;

            // 
            for (int palo = 1; palo < 5; palo++)
            {
                for (int valor = 1; valor < 14; valor++)
                {
                    mazo[contar] = new Baraja(palo, valor);
                    contar++;
                }
            }

            return mazo;
        }

        
        static void mezclarMazo(ref Baraja[] mazo)
        {
            //Implementacion del https://es.wikipedia.org/wiki/Algoritmo_de_Fisher-Yates
            // para barajar cartas mediante el uso de algoritmos aleatorios

            Random rnd = new Random();
            Baraja temp;
            int num;

            for (int i = 0; i < mazo.Length; i++)
            {
                num = rnd.Next(0, mazo.Length);

                // Intercambiar el contenido entre mazo[i] y carta[num]
                temp = mazo[i];
                mazo[i] = mazo[num];
                mazo[num] = temp;
            }

        }

        public static void CrearJugador(Jugador humano)
        {
            Console.WriteLine();
            Console.Write("\t Ingrese su nombre: ");
            humano.nombre = Console.ReadLine();

        }

        static void Main(string[] args)
        {

            Jugador humano = new Jugador();
            Jugador banca = new Jugador();
            banca.nombre = "La Banca";

            Pantallas pantallas = new Pantallas();
            bool SigueJugando = true;
            var opcion = 0;

            do
            {
                pantallas.MenuInicial();
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
                        Baraja[] mazo = generarMazo();
                        mezclarMazo(ref mazo);
                        CrearJugador(humano);
                        Repartir(ref humano, ref banca, mazo, pantallas);
                        
                        break;
                    case 2:
                        pantallas.Instrucciones();
                        break;
                    case 3:
                        SigueJugando = false;
                        break;

                }


            } while (SigueJugando);
        }

        private static void Repartir( ref Jugador humano, ref Jugador banca, Baraja[] mazo, Pantallas pantallas)
        {

            bool sePaso = false;

            //repartida inicial -> 2 barajas al humano
            pedirCarta(ref humano, mazo);
            pedirCarta(ref humano, mazo);

            //repartida inicial -> 2 barajas a la banca
            pedirCarta(ref banca, mazo);
            pedirCarta(ref banca, mazo);    

            do
            {
                pantallas.Juego(humano, banca, punteroDelMazo);
                Console.WriteLine("\t Que desea hacer?");
                Console.WriteLine("\t1.- Pedir Otra Carta | 2.- Plantarse");
                var opcion = Convert.ToInt16(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        pedirCarta(ref humano, mazo);
                        
                        break;

                    case 2:
                        while (banca.puntos < 17)
                        {
                            pedirCarta(ref banca, mazo);
                        
                        }
                        sePaso = true;
                        break;
                }

                pantallas.Juego(humano, banca, punteroDelMazo);

                if (humano.puntos > 21)
                    sePaso = true;


            } while (!sePaso);

            if(humano.puntos > 21)
            {
                Console.WriteLine();
                Console.WriteLine("\tSe paso..la Banca Gana");
                Console.ReadLine();

            }else if (banca .puntos > 21)
            {
                Console.WriteLine();
                Console.WriteLine("\tSe paso la Banca..Usted Gana");
                Console.ReadLine();

            } else if (humano.puntos > banca.puntos)
            {
                Console.WriteLine();
                Console.WriteLine("\tLa banca se planta..Usted Gana!");
                Console.ReadLine();
            }else
            {
                Console.WriteLine();
                Console.WriteLine("\tLa banca Gana!");
                Console.ReadLine();
            }
            


        }

        private static void pedirCarta(ref Jugador jugadorActual, Baraja[] mazo)
        {
            Baraja proximaCarta = mazo[punteroDelMazo]; //proxima baraja del mazo

            jugadorActual.mano[jugadorActual.barajasEnLaMano] = proximaCarta;
            jugadorActual.barajasEnLaMano++;

            //si la carta sacada del mazo es una figura, que el puntaje no sea mas de 10
            if (proximaCarta.Valor > 10)
                jugadorActual.puntos += 10;
            else
                jugadorActual.puntos += proximaCarta.Valor;

            punteroDelMazo++;
            return;
        }
    }
}
