using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    class Program
    {
        static void Main()
        {
            bool jugar = true;

            do
            {
                Menu.DibujarMenu();
                char entrada = Console.ReadKey().KeyChar;
                

                switch (entrada)
                {
                    case '1':
                        Mecanicas.Iniciar();
                        break;

                    case '2':
                        Menu.DibujarInstrucciones();
                        break;

                    case '3':
                        jugar = false;
                        Menu.DibujarSalida();
                        break;

                    default:

                        break;
                }

            } while (jugar);

          
        }
    }

    public class Mecanicas
    {

        public static void Iniciar()
        {
            
            bool NoPerdio = true;
            var adivinar = new PalabraSeleccionada();
            
            var errores = 0;
            List<char> letrasTipeadas = new List<char>();
            char[] letrasEnRayitas = adivinar.PalabraEnRayitas.ToCharArray(); ;
            List<char> letrasSecretas = new List<char>(adivinar.PalabraSecreta);
            List<char> palabraConEspacios = new List<char>(adivinar.PalabraConEspacios);


         
            
            while (NoPerdio)
            {
                
                Interface.DibujarCabecera(adivinar.CantidadDeLetras, letrasEnRayitas, errores);

                switch (errores)
                {
                    case 0:
                        DibujarAhorcado.Munieco(0);
                        break;
                    case 1:
                        DibujarAhorcado.Munieco(1);
                        break;
                    case 2:
                        DibujarAhorcado.Munieco(2);
                        break;
                    case 3:
                        DibujarAhorcado.Munieco(3);
                        break;
                    case 4:
                        DibujarAhorcado.Munieco(4);
                        break;
                    case 5:
                        DibujarAhorcado.Munieco(5);
                        break;
                    case 6:
                        DibujarAhorcado.Munieco(6);
                        break;

                    default:
                        break;
                }

                Interface.DibujarPie(letrasTipeadas);
                char letra = Console.ReadKey().KeyChar;

                if(letra == '1')
                {
                    NoPerdio = false;
                    break;
                }

                letrasTipeadas.Add(letra);


                if (letrasSecretas.Contains(letra)) //Si existe una ocurrencia en la lista de letras faltantes
                {


                    for (int i = 0; i < palabraConEspacios.Count; i++)
                    {
                        if(palabraConEspacios[i] == letra)
                        {
                            letrasEnRayitas[i] = letra;
                        }

                    }

                    letrasSecretas.RemoveAll(s => s.Equals(letra)); //removemos todas las ocurrencias de la lista
                    if(letrasSecretas.Count <= 0)
                    {
                        bool estado = true;
                        Interface.DibujarFinal(estado);
                        Console.ReadKey();
                        NoPerdio = false;

                    }


                }
                else //De lo contrario..se le suma un error
                {
                    errores++;

                    if (errores > 6) //Con 6 errores pierde
                    {
                        bool estado = false;
                        Interface.DibujarFinal(estado);
                        Console.ReadKey();
                        NoPerdio = false;

                    }
                }

            }
            
        }

    }

    public class Menu
    {
        public static void DibujarMenu()
        {
            Console.Clear();
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\tBienvenido al Juego del Ahorcado");
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\t 1.- Juego Nuevo.");
            Console.WriteLine("\t 2.- Instrucciones.");
            Console.WriteLine("\t 3.- Salir.");
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\tIngrese una opcion: ");
            Console.WriteLine("+----------------------------------------------------+");
        }

        public static void DibujarInstrucciones()
        {
            Console.Clear();
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\tINSTRUCCIONES:");
            Console.WriteLine("\tEl juego consiste en adivinar la palabra");
            Console.WriteLine("\toculta antes de que lo ahorquen!!");
            Console.WriteLine();
            Console.WriteLine("\tPresione cualquier tecla para volver");
            Console.WriteLine("+----------------------------------------------------+");
            Console.ReadKey();

        }

        public static void DibujarSalida()
        {
            Console.Clear();
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\tGracias Por Jugar!!");
            Console.WriteLine("+----------------------------------------------------+");
            Console.ReadKey();
        }


    }


    public class Interface
    {
        public static void DibujarCabecera(int longitud, char[] restantes, int intentos)
        {
            string rayitas = new string(restantes);
            Console.Clear();
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\t" + "La palabra contiene {0} letras", longitud);
            Console.WriteLine("\t" + "Le quedan {0} intentos antes de ser Ahorcado!!", intentos);
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine();
            Console.WriteLine("\t\t" + "{0}", rayitas.ToUpper());
            Console.WriteLine("+----------------------------------------------------+");

        }
  
        public static void DibujarPie(List<char> tipeadas)
        {
            
            Console.WriteLine();
            Console.WriteLine("+----------------------------------------------------+");
            Console.Write("  Letras Tipeadas hasta ahora: ");
            foreach (char letra in tipeadas)
            {
                Console.Write("{0} ", letra);
            }
            Console.WriteLine();
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine();
            Console.WriteLine("\tPresione una letra o 1 para rendirse");
            Console.WriteLine("+----------------------------------------------------+");

        }

        public static void DibujarFinal(bool estado)
        {
            Console.WriteLine("+----------------------------------------------------+");
            string mensaje;
            if (estado)
            {
                mensaje = "\tHa descubierto la Palabra Secreta!!";
            }
            else
            {
                mensaje = "\tLo han ahorcado!!";
            }
            Console.WriteLine(mensaje);
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("\tPresione una tecla para volver");
            Console.WriteLine("+----------------------------------------------------+");
        }
    }

    


    public class DibujarAhorcado
    {
        public static void Munieco(int nivel)
        {
            switch (nivel)
            {
                case 0:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 1:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 2:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 3:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|      |\\");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 4:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|     /|\\");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 5:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|     /|\\");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 6:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|     /|\\");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|       \\");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "|       |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;
                case 7:
                    Console.WriteLine("\t\t" + "+------+");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|      0 ");
                    Console.WriteLine("\t\t" + "|     /|\\");
                    Console.WriteLine("\t\t" + "|      |");
                    Console.WriteLine("\t\t" + "|     / \\");
                    Console.WriteLine("\t\t" + "|");
                    Console.WriteLine("\t\t" + "+-------+");
                    Console.WriteLine("\t\t" + "| FRITO |");
                    Console.WriteLine("\t\t" + "+-------+");
                    break;

                default:
                    break;
            }
        }
    }


    public class PalabraSeleccionada
    {
        public string PalabraSecreta { get; }
        public string PalabraEnRayitas { get; }
        public string PalabraConEspacios { get; }
        public int CantidadDeLetras { get; }

        public PalabraSeleccionada()
        {
            PalabraSecreta = Diccionario.ObtenerPalabra();
            Tuple<string, string> resultado = ObtenerRayitas();
            PalabraEnRayitas = resultado.Item1;
            PalabraConEspacios = resultado.Item2;
            CantidadDeLetras = PalabraSecreta.Length;
        }

        private Tuple<string,string> ObtenerRayitas()
        {
            int cantidad = PalabraSecreta.Length;
            int conEspacios = cantidad * 2;     //Se duplica la cantidad para agregar los espacios _ _ _..
            
            char[] caracteres = new char[conEspacios];
            char espacio = ' ';

            for(int i=0; i<conEspacios; i++)
            {
                caracteres[i] = '_';
                caracteres[i + 1] = espacio;
                i++;
            }

            Array.Resize(ref caracteres, caracteres.Length - 1); //Se quita el ultimo espacio inservible
            string devuelta = new string(caracteres);

            //--Obtiene la cadena original y le intercala un espacio a cada letra
            string devueltaTemporal = PalabraSecreta.Aggregate(string.Empty, (c, i) => c + i + ' ');
            //-- Le saco el ultimo
            string devueltaConEspacio = devueltaTemporal.Trim();


            var respuesta = Tuple.Create<string, string>(devuelta, devueltaConEspacio);
            return respuesta;

        }


    }

    class Diccionario
    {
        
        public static string ObtenerPalabra()
        {
            //La idea es tener un diccionario externo quizas en el futuro, pero para pruebas va bien la lista
            string[] palabras = new string[] { "arbol", "casa", "computadora", "cafe", "perro", "gato", "tenedor" };
            var azar = new Random();
            var elegir = azar.Next(1, palabras.Length);
            string una = palabras.GetValue(elegir).ToString();
            return una;
        }
    }
}
