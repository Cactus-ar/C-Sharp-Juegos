using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CuatroEnLinea
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Ficha> tablero;
        Ficha fichin;
        SolidColorBrush blanco;
        SolidColorBrush rojo;
        SolidColorBrush amarillo;
        
        bool turno = true; //comienza el rojo


        public MainWindow()
        {
            InitializeComponent();

            tablero = new List<Ficha>();
            blanco = new SolidColorBrush(Colors.White);
            rojo = new SolidColorBrush(Colors.Red);
            amarillo = new SolidColorBrush(Colors.Yellow);


            for (int columna = 0; columna < 7; columna++)
            {

                for (int fila = 0; fila < 6; fila++)
                {
                    fichin = new Ficha();
                    fichin.puntos.X = columna;
                    fichin.Columna = columna;
                    fichin.Fila = fila;
                    fichin.forma.MouseDown += new MouseButtonEventHandler(click);
                    fichin.Nombre = "Ficha" + columna.ToString() + fila.ToString();
                    Grid.SetRow(fichin.forma, fila);
                    Grid.SetColumn(fichin.forma, columna);
                    grilla.Children.Add(fichin.forma);
                    tablero.Add(fichin);
                }
                
            }

        }

        private bool Marca(Ficha ficha)
        {
            if(ficha.jugador == Ficha.Jugador.blanco)
            {
                if (turno)
                {
                    ficha.forma.Fill = rojo;
                    ficha.jugador = Ficha.Jugador.rojo;
                    turno = false;
                }
                else
                {
                    ficha.forma.Fill = amarillo;
                    ficha.jugador = Ficha.Jugador.amarillo;
                    turno = true;
                }
                return true;
            }
            return false;
            
        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            var forma_click = sender as Ellipse; //quien llama
            int columna = Grid.GetColumn(forma_click); //obtener columna
            int fila = Grid.GetRow(forma_click);  //obtener fila

            foreach (Ficha ficha in tablero.Reverse<Ficha>()) //iteraccion invertida para que se coloreen los ultimos primero
            {
                if (ficha.Columna == columna)   //si no esta en la columna, sigue
                {
                    if (Marca(ficha))
                    {
                        break;
                    }
                    
                }
               
            }

            //chequear si hay ganador
            int contador = 0;

            

            foreach (Ficha ficha in tablero)
            {
                tabla[ficha.Fila, ficha.Columna] = ficha.jugador.ToString();
            }

            //ss



        }

        
    }
}
