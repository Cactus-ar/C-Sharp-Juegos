namespace CarreraAviones
{
    partial class Aviones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aviones));
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.nube1 = new System.Windows.Forms.Timer(this.components);
            this.pic_nube_1 = new System.Windows.Forms.PictureBox();
            this.pic_nube_2 = new System.Windows.Forms.PictureBox();
            this.pic_nube_3 = new System.Windows.Forms.PictureBox();
            this.pic_Jugador = new System.Windows.Forms.PictureBox();
            this.pic_enemigo_1 = new System.Windows.Forms.PictureBox();
            this.pic_enemigo_2 = new System.Windows.Forms.PictureBox();
            this.pic_enemigo_3 = new System.Windows.Forms.PictureBox();
            this.pic_enemigo_4 = new System.Windows.Forms.PictureBox();
            this.pic_enemigo_5 = new System.Windows.Forms.PictureBox();
            this.img_explosion = new System.Windows.Forms.PictureBox();
            this.Bun = new System.Windows.Forms.Label();
            this.lbl_Distancia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_nube_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_nube_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_nube_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Jugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_explosion)).BeginInit();
            this.SuspendLayout();
            // 
            // pictBox
            // 
            this.pictBox.BackColor = System.Drawing.Color.Transparent;
            this.pictBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictBox.Location = new System.Drawing.Point(0, 0);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(484, 761);
            this.pictBox.TabIndex = 0;
            this.pictBox.TabStop = false;
            // 
            // nube1
            // 
            this.nube1.Enabled = true;
            this.nube1.Interval = 50;
            this.nube1.Tick += new System.EventHandler(this.Nube1_Tick);
            // 
            // pic_nube_1
            // 
            this.pic_nube_1.BackColor = System.Drawing.Color.Transparent;
            this.pic_nube_1.Image = ((System.Drawing.Image)(resources.GetObject("pic_nube_1.Image")));
            this.pic_nube_1.Location = new System.Drawing.Point(195, 48);
            this.pic_nube_1.Name = "pic_nube_1";
            this.pic_nube_1.Size = new System.Drawing.Size(277, 128);
            this.pic_nube_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_nube_1.TabIndex = 1;
            this.pic_nube_1.TabStop = false;
            // 
            // pic_nube_2
            // 
            this.pic_nube_2.BackColor = System.Drawing.Color.Transparent;
            this.pic_nube_2.Image = ((System.Drawing.Image)(resources.GetObject("pic_nube_2.Image")));
            this.pic_nube_2.Location = new System.Drawing.Point(12, 279);
            this.pic_nube_2.Name = "pic_nube_2";
            this.pic_nube_2.Size = new System.Drawing.Size(243, 126);
            this.pic_nube_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_nube_2.TabIndex = 2;
            this.pic_nube_2.TabStop = false;
            // 
            // pic_nube_3
            // 
            this.pic_nube_3.BackColor = System.Drawing.Color.Transparent;
            this.pic_nube_3.Image = ((System.Drawing.Image)(resources.GetObject("pic_nube_3.Image")));
            this.pic_nube_3.Location = new System.Drawing.Point(207, 568);
            this.pic_nube_3.Name = "pic_nube_3";
            this.pic_nube_3.Size = new System.Drawing.Size(243, 126);
            this.pic_nube_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_nube_3.TabIndex = 3;
            this.pic_nube_3.TabStop = false;
            // 
            // pic_Jugador
            // 
            this.pic_Jugador.BackColor = System.Drawing.Color.Transparent;
            this.pic_Jugador.Image = ((System.Drawing.Image)(resources.GetObject("pic_Jugador.Image")));
            this.pic_Jugador.Location = new System.Drawing.Point(195, 595);
            this.pic_Jugador.Name = "pic_Jugador";
            this.pic_Jugador.Size = new System.Drawing.Size(105, 145);
            this.pic_Jugador.TabIndex = 4;
            this.pic_Jugador.TabStop = false;
            // 
            // pic_enemigo_1
            // 
            this.pic_enemigo_1.BackColor = System.Drawing.Color.Transparent;
            this.pic_enemigo_1.Image = ((System.Drawing.Image)(resources.GetObject("pic_enemigo_1.Image")));
            this.pic_enemigo_1.Location = new System.Drawing.Point(144, 34);
            this.pic_enemigo_1.Name = "pic_enemigo_1";
            this.pic_enemigo_1.Size = new System.Drawing.Size(101, 120);
            this.pic_enemigo_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_enemigo_1.TabIndex = 5;
            this.pic_enemigo_1.TabStop = false;
            // 
            // pic_enemigo_2
            // 
            this.pic_enemigo_2.BackColor = System.Drawing.Color.Transparent;
            this.pic_enemigo_2.Image = ((System.Drawing.Image)(resources.GetObject("pic_enemigo_2.Image")));
            this.pic_enemigo_2.Location = new System.Drawing.Point(24, 154);
            this.pic_enemigo_2.Name = "pic_enemigo_2";
            this.pic_enemigo_2.Size = new System.Drawing.Size(101, 120);
            this.pic_enemigo_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_enemigo_2.TabIndex = 6;
            this.pic_enemigo_2.TabStop = false;
            // 
            // pic_enemigo_3
            // 
            this.pic_enemigo_3.BackColor = System.Drawing.Color.Transparent;
            this.pic_enemigo_3.Image = ((System.Drawing.Image)(resources.GetObject("pic_enemigo_3.Image")));
            this.pic_enemigo_3.Location = new System.Drawing.Point(371, 74);
            this.pic_enemigo_3.Name = "pic_enemigo_3";
            this.pic_enemigo_3.Size = new System.Drawing.Size(101, 120);
            this.pic_enemigo_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_enemigo_3.TabIndex = 7;
            this.pic_enemigo_3.TabStop = false;
            // 
            // pic_enemigo_4
            // 
            this.pic_enemigo_4.BackColor = System.Drawing.Color.Transparent;
            this.pic_enemigo_4.Image = ((System.Drawing.Image)(resources.GetObject("pic_enemigo_4.Image")));
            this.pic_enemigo_4.Location = new System.Drawing.Point(252, 219);
            this.pic_enemigo_4.Name = "pic_enemigo_4";
            this.pic_enemigo_4.Size = new System.Drawing.Size(101, 120);
            this.pic_enemigo_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_enemigo_4.TabIndex = 8;
            this.pic_enemigo_4.TabStop = false;
            // 
            // pic_enemigo_5
            // 
            this.pic_enemigo_5.BackColor = System.Drawing.Color.Transparent;
            this.pic_enemigo_5.Image = ((System.Drawing.Image)(resources.GetObject("pic_enemigo_5.Image")));
            this.pic_enemigo_5.Location = new System.Drawing.Point(371, 328);
            this.pic_enemigo_5.Name = "pic_enemigo_5";
            this.pic_enemigo_5.Size = new System.Drawing.Size(101, 120);
            this.pic_enemigo_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_enemigo_5.TabIndex = 9;
            this.pic_enemigo_5.TabStop = false;
            // 
            // img_explosion
            // 
            this.img_explosion.BackColor = System.Drawing.Color.Transparent;
            this.img_explosion.Image = ((System.Drawing.Image)(resources.GetObject("img_explosion.Image")));
            this.img_explosion.Location = new System.Drawing.Point(189, 580);
            this.img_explosion.Name = "img_explosion";
            this.img_explosion.Size = new System.Drawing.Size(111, 169);
            this.img_explosion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_explosion.TabIndex = 10;
            this.img_explosion.TabStop = false;
            this.img_explosion.Visible = false;
            // 
            // Bun
            // 
            this.Bun.AutoSize = true;
            this.Bun.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bun.Location = new System.Drawing.Point(92, 277);
            this.Bun.Name = "Bun";
            this.Bun.Size = new System.Drawing.Size(301, 108);
            this.Bun.TabIndex = 11;
            this.Bun.Text = "Bun !!";
            this.Bun.Visible = false;
            // 
            // lbl_Distancia
            // 
            this.lbl_Distancia.AutoSize = true;
            this.lbl_Distancia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_Distancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Distancia.Location = new System.Drawing.Point(303, 21);
            this.lbl_Distancia.Name = "lbl_Distancia";
            this.lbl_Distancia.Size = new System.Drawing.Size(90, 24);
            this.lbl_Distancia.TabIndex = 12;
            this.lbl_Distancia.Text = "Distancia:";
            // 
            // Aviones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.lbl_Distancia);
            this.Controls.Add(this.Bun);
            this.Controls.Add(this.img_explosion);
            this.Controls.Add(this.pic_enemigo_5);
            this.Controls.Add(this.pic_enemigo_4);
            this.Controls.Add(this.pic_enemigo_3);
            this.Controls.Add(this.pic_enemigo_2);
            this.Controls.Add(this.pic_enemigo_1);
            this.Controls.Add(this.pic_Jugador);
            this.Controls.Add(this.pic_nube_3);
            this.Controls.Add(this.pic_nube_2);
            this.Controls.Add(this.pic_nube_1);
            this.Controls.Add(this.pictBox);
            this.MaximumSize = new System.Drawing.Size(500, 800);
            this.MinimumSize = new System.Drawing.Size(500, 800);
            this.Name = "Aviones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carrera de Aviones";
            this.Load += new System.EventHandler(this.Aviones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Aviones_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_nube_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_nube_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_nube_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Jugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_enemigo_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_explosion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.Timer nube1;
        private System.Windows.Forms.PictureBox pic_nube_1;
        private System.Windows.Forms.PictureBox pic_nube_2;
        private System.Windows.Forms.PictureBox pic_nube_3;
        private System.Windows.Forms.PictureBox pic_Jugador;
        private System.Windows.Forms.PictureBox pic_enemigo_1;
        private System.Windows.Forms.PictureBox pic_enemigo_2;
        private System.Windows.Forms.PictureBox pic_enemigo_3;
        private System.Windows.Forms.PictureBox pic_enemigo_4;
        private System.Windows.Forms.PictureBox pic_enemigo_5;
        private System.Windows.Forms.PictureBox img_explosion;
        private System.Windows.Forms.Label Bun;
        private System.Windows.Forms.Label lbl_Distancia;
    }
}

