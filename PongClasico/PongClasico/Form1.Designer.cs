namespace PongClasico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pic_Jugador = new System.Windows.Forms.PictureBox();
            this.pic_Cpu = new System.Windows.Forms.PictureBox();
            this.pic_Bola = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pic_Red = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Jugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Bola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Red)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Jugador
            // 
            this.pic_Jugador.BackColor = System.Drawing.Color.Blue;
            this.pic_Jugador.Location = new System.Drawing.Point(86, 64);
            this.pic_Jugador.Name = "pic_Jugador";
            this.pic_Jugador.Size = new System.Drawing.Size(21, 117);
            this.pic_Jugador.TabIndex = 0;
            this.pic_Jugador.TabStop = false;
            // 
            // pic_Cpu
            // 
            this.pic_Cpu.BackColor = System.Drawing.Color.Red;
            this.pic_Cpu.Location = new System.Drawing.Point(166, 64);
            this.pic_Cpu.Name = "pic_Cpu";
            this.pic_Cpu.Size = new System.Drawing.Size(21, 117);
            this.pic_Cpu.TabIndex = 1;
            this.pic_Cpu.TabStop = false;
            // 
            // pic_Bola
            // 
            this.pic_Bola.Image = ((System.Drawing.Image)(resources.GetObject("pic_Bola.Image")));
            this.pic_Bola.Location = new System.Drawing.Point(362, 149);
            this.pic_Bola.Name = "pic_Bola";
            this.pic_Bola.Size = new System.Drawing.Size(32, 32);
            this.pic_Bola.TabIndex = 2;
            this.pic_Bola.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // pic_Red
            // 
            this.pic_Red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pic_Red.Location = new System.Drawing.Point(372, -1);
            this.pic_Red.Name = "pic_Red";
            this.pic_Red.Size = new System.Drawing.Size(10, 451);
            this.pic_Red.TabIndex = 3;
            this.pic_Red.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pic_Bola);
            this.Controls.Add(this.pic_Cpu);
            this.Controls.Add(this.pic_Jugador);
            this.Controls.Add(this.pic_Red);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teclaHaciaAbajo);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.teclaHaciaArriba);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Jugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Bola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Red)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Jugador;
        private System.Windows.Forms.PictureBox pic_Cpu;
        private System.Windows.Forms.PictureBox pic_Bola;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pic_Red;
    }
}

