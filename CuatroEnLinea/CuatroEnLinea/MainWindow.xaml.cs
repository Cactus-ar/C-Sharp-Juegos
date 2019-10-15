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
        private char[,] marcador;
        List<Ficha> tablero;
        Ficha fichin;
        SolidColorBrush blanco;
        SolidColorBrush rojo;
        SolidColorBrush amarillo;
        
        bool turno = true; //comienza el rojo


        public MainWindow()
        {
            InitializeComponent();
            Iniciar();
            

        }

        private void Iniciar()
        {

            marcador = new char[6, 7];
            tablero = new List<Ficha>();
            blanco = new SolidColorBrush(Colors.White);
            rojo = new SolidColorBrush(Colors.Red);
            amarillo = new SolidColorBrush(Colors.Yellow);
            for (int columna = 0; columna < 7; columna++)
            {

                for (int fila = 0; fila < 6; fila++)
                {
                    fichin = new Ficha();
                    fichin.Columna = columna;
                    fichin.Fila = fila;
                    fichin.forma.MouseDown += new MouseButtonEventHandler(Click);
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
                    marcador[ficha.Fila, ficha.Columna] = 'R';
                    ficha.forma.Fill = rojo;
                    ficha.jugador = Ficha.Jugador.rojo;
                    turno = false;
                }
                else
                {
                    marcador[ficha.Fila, ficha.Columna] = 'Y';
                    ficha.forma.Fill = amarillo;
                    ficha.jugador = Ficha.Jugador.amarillo;
                    turno = true;
                }
                return true;
            }
            return false;
            
        }

        private bool ChequearGanador(char juega)
        {
            // horizontal
            for (int j = 0; j < 7 - 3; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (marcador[i,j] == juega && 
                        marcador[i,j + 1] == juega && 
                        marcador[i,j + 2] == juega && 
                        marcador[i,j + 3] == juega)
                    {
                        return true;
                    }
                }
            }
            // vertical
            for (int i = 0; i < 6 - 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (marcador[i,j] == juega && 
                        marcador[i + 1,j] == juega && 
                        marcador[i + 2,j] == juega && 
                        marcador[i + 3,j] == juega)
                    {
                        return true;
                    }
                }
            }
            // diagonal ascendente
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 7 - 3; j++)
                {
                    if (marcador[i,j] == juega && 
                        marcador[i - 1, j + 1] == juega && 
                        marcador[i - 2, j + 2] == juega &&
                        marcador[i - 3, j + 3] == juega)
                        return true;
                }
            }
            // diagonal descendente
            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 7; j++)
                {
                    if (marcador[i,j] == juega && 
                        marcador[i - 1, j - 1] == juega &&
                        marcador[i - 2, j - 2] == juega && 
                        marcador[i - 3, j - 3] == juega)
                        return true;
                }
            }
            return false;
        }


        private void Click(object sender, MouseButtonEventArgs e)
        {
            var forma_click = sender as Ellipse; //quien llama
            int columna = Grid.GetColumn(forma_click); //obtener columna

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
            if (turno)
            {
                if (ChequearGanador('Y'))
                {
                    label1.Content = "Ganó el Jugador Amarillo!!!";
                    label1.Visibility = Visibility.Visible;
                    btn_init.Visibility = Visibility.Visible;
                    foreach (Ficha ficha in tablero)
                    {
                        ficha.forma.Fill = amarillo;
                    }
                }
                    
            }
            else
            {
                if (ChequearGanador('R'))
                {
                    label1.Content = "Ganó el Jugador Rojo!!!!!";
                    label1.Visibility = Visibility.Visible;
                    btn_init.Visibility = Visibility.Visible;
                    foreach (Ficha ficha in tablero)
                    {
                        ficha.forma.Fill = rojo;
                    }
                }
                    
            }

        }

        private void Btn_init_Click(object sender, RoutedEventArgs e)
        {
            //reinicializar
            label1.Content = "";
            label1.Visibility = Visibility.Hidden;
            btn_init.Visibility = Visibility.Hidden;
            tablero.Clear();
            grilla.Children.Clear();
            turno = true;
            Iniciar();
        }
    }
}
