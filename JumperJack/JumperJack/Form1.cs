using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumperJack
{
    public partial class Form1 : Form
    {

        Random posy;
        Jugador jugador;
        Obstaculo obst;
        List<Obstaculo> obstaculos;
        

        public Form1()
        {
            InitializeComponent();
            posy = new Random();
            obstaculos = new List<Obstaculo>();
            jugador = new Jugador();
            jugador.Dibujar(this);
            jugador.EstablecerPosicion(150, 20);
            lbl_vidas.Text = "Vidas: " + jugador.Vidas.ToString();

           
            

        }

        private void Tmr_gravedad_Tick(object sender, EventArgs e)
        {
            if (!jugador.imagen.Bounds.IntersectsWith(pic_pasto.Bounds) && jugador.EstaSaltando == false)
            {
                jugador.imagen.Top += 10;
            }
        }

        private void Tmr_Salta_Tick(object sender, EventArgs e)
        {
                jugador.imagen.Top -= 15;
                jugador.EstaSaltando = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                tmr_Salta.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                jugador.EstaSaltando = false;
                tmr_Salta.Stop();
            }
        }

        private void Tmr_Obstaculos_Tick(object sender, EventArgs e)
        {
            
            //cada intervalo de tiempo nace un obstaculo desde el borde derecho de la pantalla
            

            obst = new Obstaculo();
            obst.Dibujar(this);
            obst.EstablecerPosicion(600, 250);
            obstaculos.Add(obst);

        }

        private void Tmr_obstaculos_mueven_Tick(object sender, EventArgs e)
        {
            foreach (var obsaculo in obstaculos)
            {
                obsaculo.imagen.Left -= 10;
                if (obsaculo.imagen.Left <= 0)
                   obstaculos.Remove(obsaculo);
            }
        }
    }


    public abstract class Entidad
    {
        public PictureBox imagen;

        public Entidad()
        {
          imagen = new PictureBox();
        }

        public void Dibujar(Form form)
        {
            form.Controls.Add(imagen);
        }

        public Rectangle ObtenerBordes()
        {
            return imagen.Bounds;
        }

        public void EstablecerPosicion(int posX, int posY)
        {
            imagen.Location = new Point(posX, posY);
        }

    }


    public class Jugador : Entidad
    {
        public int Vidas { get; set; }
        public bool EstaSaltando { get; set; }

        public Jugador()
        {
            Vidas = 3;
            EstaSaltando = false;
            imagen.BackColor = Color.Blue;
            imagen.Size = new Size(35, 35);

        }
        
    }

    public class Obstaculo : Entidad
    {
        public Obstaculo()
        {
            imagen.Size = new Size(25, 30);
            imagen.BackColor = Color.Red;

        }
    }
}
