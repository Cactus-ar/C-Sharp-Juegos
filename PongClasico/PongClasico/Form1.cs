using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongClasico
{
    public partial class Form1 : Form
    {

        struct BolaXY
        {
            public int x;
            public int y;
        }

        bool haciaArriba;
        bool haciaAbajo;
        int compuSpeed;
        int compuPuntaje;
        int jugadorSpeed;
        int jugadorPuntaje;
        Random random;
        BolaXY bolaXY;




        public Form1()
        {
            InitializeComponent();
            jugadorSpeed = 5;
            compuSpeed = 5;
            jugadorPuntaje = 0;
            compuPuntaje = 0;
            random = new Random();
            bolaXY.x = 10;
            bolaXY.y = 10;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //fixear el form
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ActualizarPuntaje();

            //pos de la red
            pic_Red.Top = 0;
            pic_Red.Left = (ClientSize.Width - pic_Red.Width) / 2;
            pic_Red.Height = ClientSize.Height;

            //posicion de la paleta dle jugador
            pic_Jugador.Left = 5;
            pic_Jugador.Top = (ClientSize.Height - pic_Jugador.Height) / 2;

            //pos de la paleta de la cpu
            pic_Cpu.Left = (ClientSize.Width - pic_Cpu.Width) - 5;
            pic_Cpu.Top = (ClientSize.Height - pic_Cpu.Height) / 2;


            //pos de la bola
            pic_Bola.Left = (ClientSize.Width / 2) - 15;
            pic_Bola.Top = (ClientSize.Height / 2) - 15;

        }

        private void teclaHaciaAbajo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                haciaArriba = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                haciaAbajo = true;
            }
        }

        private void teclaHaciaArriba(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                haciaArriba = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                haciaAbajo = false;
            }
        }

        private void ActualizarPuntaje()
        {
            this.Text = "Jugador: " + jugadorPuntaje + " - Compu: " + compuPuntaje;
            return;
        }

        private void ActualizarBola()
        {
            pic_Bola.Left = (ClientSize.Width / 2) - 15; //bola al medio
            pic_Bola.Top = random.Next(ClientSize.Height);  //bola aleatorio en el ejeY
            bolaXY.x *= -1; //cambiar direccion
            return;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            ActualizarPuntaje();

            //init la bola
            pic_Bola.Top -= bolaXY.y;
            pic_Bola.Left -= bolaXY.x;

            //init CPU
            pic_Cpu.Top += compuSpeed;
            if (pic_Cpu.Top < 0 || pic_Cpu.Top > ClientSize.Height - pic_Cpu.Height)
            {
                compuSpeed *= -1;   //si colisiona con los bordes superior o inferior cambia de rumbo
            }

            //cpu gana
            if(pic_Bola.Left < 0) //jugador manco - bola colisiona con el borde izquierdo
            {
                ActualizarBola();
                compuPuntaje++;
            }

            //jugador gana
            if (pic_Bola.Left + pic_Bola.Width > ClientSize.Width) //cpu no llega..colision con el borde derecho
            {
                ActualizarBola();
                jugadorPuntaje++; 
            }

            //bola colisiona con los bordes superior e inferior
            if (pic_Bola.Top < 0 || pic_Bola.Top + pic_Bola.Height > ClientSize.Height)
            {
                bolaXY.y *= -1;
            }


            //bola colisiona contra la paleta del jugador o del cpu
            if (pic_Bola.Bounds.IntersectsWith(pic_Jugador.Bounds) || pic_Bola.Bounds.IntersectsWith(pic_Cpu.Bounds))
            {
                bolaXY.x *= -1; //rebota en sentido contrario
            }

            //actualizar la paleta del usuario
            if (haciaArriba && pic_Jugador.Top > 0)
            {
                pic_Jugador.Top -= jugadorSpeed;
            }
            if (haciaAbajo && pic_Jugador.Top < ClientSize.Height - pic_Jugador.Height)
            {
                pic_Jugador.Top += jugadorSpeed;
            }

            //final del juego
            if (jugadorPuntaje >= 10)
            {
                timer.Stop();
                MessageBox.Show("Ha Ganado la Super Partida");
            }
            if (compuPuntaje >= 10)
            {
                timer.Stop();
                MessageBox.Show("La compu ha ganado..un manco");
            }

        }
    }
}
