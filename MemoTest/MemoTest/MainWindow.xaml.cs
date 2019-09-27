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
using System.Windows.Threading;

//Tipico juego de encontrar el par de fichas



namespace MemoTest
{
    


    public class Ficha
    {
        public Rectangle Forma { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
        public int IndiceImagen { get; set; }


        public Ficha(Rectangle rectangle, string nombre, int indice,  bool activo)
        {
            Forma = rectangle;
            Nombre = nombre;
            IndiceImagen = indice;
            EstaActivo = activo;
            
        }

    }
       


    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Ficha> tablero;
        List<BitmapImage> imagenes;
        DispatcherTimer timer;
        Rectangle recTemp;
        int segundos;
        

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);

            Inicializa();
        }

        private void Inicializa()
        {

            Random rng = new Random();
            tablero = new List<Ficha>();
            imagenes = new List<BitmapImage>();
            string carpeta = "C:\\Users\\directorioDelProyecto\\Imagenes\\";
            BitmapImage icono = new BitmapImage();
            var posXIni = 10;
            var posYIni = 10;
            var indiceImagen = 0;
            var cuenta = 0;

            btn_nueva.Visibility = Visibility.Hidden;
            lbl_gano.Visibility = Visibility.Hidden;

            //10 imagenes


            icono.BeginInit();
                icono.UriSource = new Uri(@carpeta +"anana.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "frambuesa.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "higo.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "limon.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "manzana.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "naranja.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "pera.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "sandia.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "tomate.png");
                icono.EndInit();
                imagenes.Add(icono);

                icono = new BitmapImage();
                icono.BeginInit();
                icono.UriSource = new Uri(@carpeta + "uvas.png");
                icono.EndInit();
                imagenes.Add(icono);




            //20 fichas
            for (int i = 0; i < 20; i++)
            {
                recTemp = new Rectangle
                {
                    Name = "Ficha_" + i,
                    Fill = new SolidColorBrush(Colors.Blue),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 70,
                    Margin = new Thickness(5, 5, 5, 5),
                    Stroke = new SolidColorBrush(Colors.Black),
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 70,
                    StrokeThickness = 3
                };

               

                recTemp.MouseDown += RecTemp_MouseDown;

                tablero.Add(new Ficha(recTemp, recTemp.Name.ToString(), indiceImagen, false));

                indiceImagen++;
                if (indiceImagen >= 10)
                    indiceImagen = 0;
            }

            //ordenar la lista de forma aleatoria (pseudo)
            int orden = tablero.Count();
            int ultimo = orden - 1;
            for (int i = 0; i < ultimo; i++)
            {
                var pos = rng.Next(i, orden);
                var temporal = tablero[i];
                tablero[i] = tablero[pos];
                tablero[pos] = temporal;
            }
           
            segundos = 0;
            timer.Start();

            //pintar tablero
            foreach (var item in tablero)
            {

                if(cuenta == 5)
                {
                    posXIni = 10;
                    posYIni += 80;
                    cuenta = 0;
                }

                Canvas.SetLeft(item.Forma, posXIni);
                Canvas.SetTop(item.Forma, posYIni);
                canvas.Children.Add(item.Forma);
                posXIni += 80;
                cuenta++;
            }
            

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lbl_segundos.Content = segundos++;
        }

        private void RecTemp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var figura = sender as Rectangle;
            var fichin = tablero.Find(i => i.Forma == figura);

            if (fichin.EstaActivo)
            {
                fichin.EstaActivo = false;
                fichin.Forma.Fill = new SolidColorBrush(Colors.Blue);
                fichin.Forma.Stroke = new SolidColorBrush(Colors.Black);

            }else
            {
                fichin.EstaActivo = true;
                fichin.Forma.Fill = new ImageBrush(imagenes[fichin.IndiceImagen]);
                fichin.Forma.Stroke = new SolidColorBrush(Colors.Blue);

                foreach (var fichi in tablero)
                {

                    if (!fichi.Equals(fichin))
                    {
                        //si hay otro activo..son 2
                        if (fichi.EstaActivo)
                        {

                            var indice_imagen_1 = fichin.IndiceImagen;
                            var indice_imagen_2 = fichi.IndiceImagen;

                            if (imagenes[indice_imagen_1].UriSource == imagenes[indice_imagen_2].UriSource)
                            {
                                //si coinciden...removerlas y actualizar puntaje
                                fichin.Forma.Visibility = Visibility.Hidden;
                                tablero.Remove(fichin);

                                fichi.Forma.Visibility = Visibility.Hidden;
                                tablero.Remove(fichi);
                                break;
                            }else
                            {
                                //si no, resetear las imagenes y las banderas
                                fichi.Forma.Fill = new SolidColorBrush(Colors.Blue);
                                fichi.Forma.Stroke = new SolidColorBrush(Colors.Black);
                                fichi.EstaActivo = false;

                                fichin.Forma.Fill = new SolidColorBrush(Colors.Blue);
                                fichin.Forma.Stroke = new SolidColorBrush(Colors.Black);
                                fichin.EstaActivo = false;
                                break;
                            }

                            
                            
                        }
                    }

            
                        
                }
                
            }

            if(tablero.Count == 0) //termino la partida
            {
                btn_nueva.Visibility = Visibility.Visible;
                lbl_gano.Visibility = Visibility.Visible;
                timer.Stop();
                
            }
        }

        private void Btn_nueva_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            tablero.Clear();
            imagenes.Clear();
            Inicializa();
        }
    }
}
