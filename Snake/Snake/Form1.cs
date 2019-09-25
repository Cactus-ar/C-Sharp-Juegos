using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snake : Form
    {
        Random rand;
        enum EstadoDelTablero
        {
            Libre,
            Snake,
            Fruta
        };
        enum Direccion
        {
            Arriba,
            Abajo,
            Izquierda,
            Derecha
        };

        struct CoordenadasSnake
        {
            public int x;
            public int y;
        }

        EstadoDelTablero[,] tablero;
        CoordenadasSnake[] PosicionSnake;
        int largoSnake;
        Direccion direccion;
        Graphics pintar;



        public Snake()
        {
            InitializeComponent();
            tablero = new EstadoDelTablero[11, 11]; //El tamaño del tablero incluyendo las paredes
            PosicionSnake = new CoordenadasSnake[100]; //el tamaño maximo de la snake no puede ser mayo a 100 ya que el tblero es de 10x10
            rand = new Random();
        }

        private void Snake_Load(object sender, EventArgs e)
        {
            pic_game.Image = new Bitmap(420, 420);      //crear un nuevo bitmap
            pintar = Graphics.FromImage(pic_game.Image);    //agregarlo al manejador
            pintar.Clear(Color.White);   //pintar de blanco

            //pintar paredes
            for (int i = 1; i <= 10; i++)
            {
                //pared superior e inferior
                pintar.DrawImage(img_lista.Images[6], i * 35, 0); //pared superior
                pintar.DrawImage(img_lista.Images[6], i * 35, 385); //pared inferior

            }
            for (int i = 0; i <= 11; i++)
            {
                //pared izquierda y derecha
                pintar.DrawImage(img_lista.Images[6], 0, i*35); 
                pintar.DrawImage(img_lista.Images[6], 385, i*35);

            }

            //pintar la serpiente y ubicar su posicion inicial en el array
            PosicionSnake[0].x = 5; //centro de la pantalla -> cabeza
            PosicionSnake[0].y = 5;
            PosicionSnake[1].x = 5;// debajo parte del cuerpo
            PosicionSnake[1].y = 6;
            PosicionSnake[2].x = 5; //otra parte del cuerpo
            PosicionSnake[2].y = 7;

            pintar.DrawImage(img_lista.Images[5], 5 * 35, 5 * 35); //cabeza
            pintar.DrawImage(img_lista.Images[4], 5 * 35, 6 * 35); //cuerpo
            pintar.DrawImage(img_lista.Images[4], 5 * 35, 7 * 35); //cuerpo

            //Ubicar el estado del tablero, las casillas que se encuentran ocupadas con la snake
            tablero[5, 5] = EstadoDelTablero.Snake;
            tablero[5, 6] = EstadoDelTablero.Snake;
            tablero[5, 7] = EstadoDelTablero.Snake;

            largoSnake = 3; //tamaño inicial

            direccion = Direccion.Arriba; //direccion inicial

            //pintar las frutas
            for (int i = 0; i < 4; i++)
            {
                Frutas();
            }


        }

        private void Frutas()
        {
            int x, y;
            var indiceImagenes = rand.Next(0, 4); //seleccionar una fruta aleatoria

            do
            {
                //basicamente buscamos una casilla libre en el tablero para colocar la fruta
                //el bucle genera aleatoriamente posiciones hasta que encuentra una libre
                x = rand.Next(1, 10);
                y = rand.Next(1, 10);

            } while (tablero[x,y] != EstadoDelTablero.Libre);

            //una vez que lo encontro, pintamos la fruta
            tablero[x, y] = EstadoDelTablero.Fruta;
            pintar.DrawImage(img_lista.Images[indiceImagenes], x * 35, y * 35);

        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            //cada presion de tecla...
            switch (e.KeyCode)
            {
                case Keys.Up:
                    direccion = Direccion.Arriba;
                    break;
                case Keys.Down:
                    direccion = Direccion.Abajo;
                    break;
                case Keys.Left:
                    direccion = Direccion.Izquierda;
                    break;
                case Keys.Right:
                    direccion = Direccion.Derecha;
                    break;
            }
        }

        private void GameOver()
        {
            timer.Enabled = false;  //Detenemos el timer
            MessageBox.Show("Fin del Juego!");
            pintar.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //con cada tic del timer ajustamos la serpiente y elementos del juego
            

            pintar.FillRectangle(Brushes.White, 
                PosicionSnake[largoSnake - 1].x * 35, 
                PosicionSnake[largoSnake - 1].y * 35,
                35, 35); //pintamos la cola de la snake de blanco al avanzar

            tablero[PosicionSnake[largoSnake - 1].x, PosicionSnake[largoSnake - 1].y] = EstadoDelTablero.Libre; //liberar el cuadrado

            //mover el cuerpo de la serpiente a la posicion previa
            for (int i = largoSnake; i >= 1; i--)
            {
                PosicionSnake[i].x = PosicionSnake[i - 1].x;
                PosicionSnake[i].y = PosicionSnake[i - 1].y;
            }

            pintar.DrawImage(img_lista.Images[4], PosicionSnake[0].x * 35, PosicionSnake[0].y * 35, 35, 35);
            //pintar cabeza segun tecla
            switch (direccion)
            {
                case Direccion.Arriba:
                    PosicionSnake[0].y -= 1;
                    break;
                case Direccion.Abajo:
                    PosicionSnake[0].y += 1;
                    break;
                case Direccion.Izquierda:
                    PosicionSnake[0].x -= 1;
                    break;
                case Direccion.Derecha:
                    PosicionSnake[0].x += 1;
                    break;
                default:
                    break;
            }

            //chequear colisiones
            //cabeza contra la pared
            if(PosicionSnake[0].x < 1 || PosicionSnake[0].x > 10 || PosicionSnake[0].y < 1 || PosicionSnake[0].y > 10)
            {
                GameOver();
                pic_game.Refresh();
                return;

            }
            //colision contra el cuerpoç
            if(tablero[PosicionSnake[0].x, PosicionSnake[0].y] == EstadoDelTablero.Snake)
            {
                GameOver();
                pic_game.Refresh();
                return;

            }
            //colision contra una fruta
            if (tablero[PosicionSnake[0].x, PosicionSnake[0].y] == EstadoDelTablero.Fruta)
            {
                //para mantenerlo simple solo crece, pero podria tener diferentes estados segun la fruta
                pintar.DrawImage(img_lista.Images[4], PosicionSnake[largoSnake].x * 35, PosicionSnake[largoSnake].y * 35);
                tablero[PosicionSnake[largoSnake].x, PosicionSnake[largoSnake].y] = EstadoDelTablero.Snake;
                largoSnake++;

                if(largoSnake < 96) //no puede haber bonux mas que con un largo de 96 de lo contrario el loop de fruta caeria en infinito
                {
                    Frutas();
                }

                this.Text = "Puntaje: " + largoSnake;

            }

            //refrescar cabeza
            pintar.DrawImage(img_lista.Images[5], PosicionSnake[0].x * 35, PosicionSnake[0].y * 35, 35, 35);
            tablero[PosicionSnake[0].x, PosicionSnake[0].y] = EstadoDelTablero.Snake;
            pic_game.Refresh();




        }
    }
}
