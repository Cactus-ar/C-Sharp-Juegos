using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CuatroEnLinea
{
    public class Ficha
    {

        public enum Jugador
        {
            blanco,
            rojo,
            amarillo
        };


        public Ellipse forma;
        public Point puntos { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
        public Jugador jugador { get; set; }
        public string Nombre { get; set; }

        public Ficha()
        {
            puntos = new Point();
            forma = new Ellipse
            {
                Fill = new SolidColorBrush(Colors.White),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };

            jugador = Jugador.blanco;

        }

    }
}
