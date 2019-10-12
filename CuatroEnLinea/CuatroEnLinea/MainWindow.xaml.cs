using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CuatroEnLinea
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        
        Ellipse fichin;

        public MainWindow()
        {
            InitializeComponent();
        
            for (int columna = 0; columna < 7; columna++)
            {

                for (int fila = 0; fila < 6; fila++)
                {
                    fichin = new Ellipse();
                    fichin.Fill = new SolidColorBrush(Colors.White);
                    fichin.Stroke = new SolidColorBrush(Colors.Black);
                    fichin.StrokeThickness = 2;
                    fichin.MouseDown += new MouseButtonEventHandler(click);
                    Grid.SetRow(fichin, fila);
                    Grid.SetColumn(fichin, columna);
                    grilla.Children.Add(fichin);
                }
                
            }

        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            
            var blanco = new SolidColorBrush(Colors.White);
            var rojo = new SolidColorBrush(Colors.Red);
            var amarillo = new SolidColorBrush(Colors.Yellow);

            var ficha = sender as Ellipse; //quien llama

            int columna = Grid.GetColumn(ficha); //obtener columna
            int fila = Grid.GetRow(ficha);  //obtener fila


            //debug
            label1.Content = columna;
            label2.Content = fila;
            label3.Content = ficha.Fill;


            
            



        }

        
    }
}
