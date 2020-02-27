using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalTrees
{

    /* La intencion es ver los cambios realizados a la
     * gdi (https://es.wikipedia.org/wiki/Graphics_Device_Interface)
     * de windows con net framework.
     * 
     */


    public partial class Form1 : Form
    {

        static public Pen p = new Pen(Color.Black, 1);
        static public Graphics g;
        static public double gradoAradian = Math.PI / 180.0;
        static readonly object redibuja = new object();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GenerarArbol(float x1, float y1, double angulo, int ramas, double rotacion)
        {
            try
            {
                if (ramas != 0)
                {

                    float x2 = (float)(x1 + (Math.Cos(angulo * gradoAradian) * ramas * 10.0));
                    float y2 = (float)(y1 + (Math.Sin(angulo * gradoAradian) * ramas * 10.0));
                    lock (redibuja)
                    {
                        this.Update();
                        p.Color = Color.Green;
                        g.DrawLine(p, x1, y1, x2, y2);
                    }

                    GenerarArbol(x2, y2, angulo - rotacion, ramas - 1, rotacion); //Izquierdo
                    GenerarArbol(x2, y2, angulo + rotacion, ramas - 1, rotacion); //Derecho

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Dibujar(object sender, PaintEventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.Black);
            GenerarArbol((this.Width) / 2, (this.Height - 5), -90.0, 11, 20);
        }
    }
}
