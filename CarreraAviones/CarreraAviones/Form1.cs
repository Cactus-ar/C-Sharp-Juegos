using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarreraAviones
{
   
    public partial class Aviones : Form
    {
        
        enum Direccion
        {
            Izquierda,
            Derecha
        };


        Direccion direccion;
        List<PictureBox> enemigos;
        int distancia;
        


        public Aviones()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            distancia = 0;
            //Generar coleccion de aviones enemigos
            enemigos = new List<PictureBox>();
            enemigos.Add(pic_enemigo_1);
            enemigos.Add(pic_enemigo_2);
            enemigos.Add(pic_enemigo_3);
            enemigos.Add(pic_enemigo_4);
            enemigos.Add(pic_enemigo_5);

            foreach (var enemigo in enemigos)
            {
             
                enemigo.Visible = false;        
                enemigo.Top = -enemigo.Height;
            }


        }

        private void Aviones_Load(object sender, EventArgs e)
        {
            //rotar las imagenes ya que se encuentran boca arriba
            pic_enemigo_1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pic_enemigo_2.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pic_enemigo_3.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pic_enemigo_4.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pic_enemigo_5.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

        }

      

        private void Nube1_Tick(object sender, EventArgs e)
        {
            
            Random enemyRnd = new Random();
            distancia++;

            //Paralax de nubes
            Random cordY = new Random();
            pic_nube_1.Top += 6;
            pic_nube_2.Top += 4;
            pic_nube_3.Top += 2;

            if (pic_nube_1.Top >= this.Height)
            {
                pic_nube_1.Top = -pic_nube_1.Height;
                pic_nube_1.Left = cordY.Next(10, 400);
            }

            if (pic_nube_2.Top >= this.Height)
            {
                pic_nube_2.Top = -pic_nube_2.Height;
                pic_nube_2.Left = cordY.Next(10, 400);
            }

            if (pic_nube_3.Top >= this.Height)
            {
                pic_nube_3.Top = -pic_nube_3.Height;
                pic_nube_3.Left = cordY.Next(10, 400);
            }

            //Movimiento del Jugador
            switch (direccion)
            {
                case Direccion.Izquierda:
                    pic_Jugador.Left -= 5;
                    break;
                case Direccion.Derecha:
                    pic_Jugador.Left += 5;
                    break;
                
            }
            //control de colision con bordes derecho e izquierdo del formulario
            if (pic_Jugador.Location.X <= 10)
                pic_Jugador.Left = 10;
            if (pic_Jugador.Location.X >= 379)
                pic_Jugador.Left = 379;


            //enemigos


            foreach (var enemigo in enemigos)
            {
                var alto = enemigo.Height;

                if(enemigo.Top > this.Height) 
                {
                    //No esta en la pantalla - vuelve arriba
                    enemigo.Top -= this.Height + enemigo.Height;

                    if (enemyRnd.Next(1, 10) > 5) //basicamente 50% chance que haya un spawn
                        enemigo.Visible = true;
                    else
                        enemigo.Visible = false;

                }
                else
                {

                    enemigo.Top += 6;                    
                }
            }

            //distancia
            lbl_Distancia.Text = "Distancia: " + distancia.ToString();

            //colision
            foreach (var enemigo in enemigos)
            {
                if (enemigo.Visible)
                {
                    if (enemigo.Bounds.IntersectsWith(pic_Jugador.Bounds))
                    {

                        img_explosion.Top = pic_Jugador.Location.Y;
                        img_explosion.Left = pic_Jugador.Location.X;
                        img_explosion.Visible = true;
                        nube1.Stop();
                        Bun.Visible = true;
                        break;
                    }
                }

            }

        }

        private void Aviones_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    direccion = Direccion.Izquierda;
                    break;
                case Keys.Right:
                    direccion = Direccion.Derecha;
                    break;
            }
        }
    }

   
}
