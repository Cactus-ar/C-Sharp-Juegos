namespace JumperJack
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
            this.pic_pasto = new System.Windows.Forms.PictureBox();
            this.tmr_gravedad = new System.Windows.Forms.Timer(this.components);
            this.lbl_vidas = new System.Windows.Forms.Label();
            this.tmr_Salta = new System.Windows.Forms.Timer(this.components);
            this.tmr_Obstaculos_spawn = new System.Windows.Forms.Timer(this.components);
            this.tmr_obstaculos_mueven = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_pasto)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_pasto
            // 
            this.pic_pasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pic_pasto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pic_pasto.Location = new System.Drawing.Point(0, 278);
            this.pic_pasto.Name = "pic_pasto";
            this.pic_pasto.Size = new System.Drawing.Size(604, 70);
            this.pic_pasto.TabIndex = 0;
            this.pic_pasto.TabStop = false;
            // 
            // tmr_gravedad
            // 
            this.tmr_gravedad.Enabled = true;
            this.tmr_gravedad.Interval = 10;
            this.tmr_gravedad.Tick += new System.EventHandler(this.Tmr_gravedad_Tick);
            // 
            // lbl_vidas
            // 
            this.lbl_vidas.AutoSize = true;
            this.lbl_vidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_vidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vidas.Location = new System.Drawing.Point(12, 314);
            this.lbl_vidas.Name = "lbl_vidas";
            this.lbl_vidas.Size = new System.Drawing.Size(70, 25);
            this.lbl_vidas.TabIndex = 3;
            this.lbl_vidas.Text = "label1";
            // 
            // tmr_Salta
            // 
            this.tmr_Salta.Interval = 10;
            this.tmr_Salta.Tick += new System.EventHandler(this.Tmr_Salta_Tick);
            // 
            // tmr_Obstaculos_spawn
            // 
            this.tmr_Obstaculos_spawn.Enabled = true;
            this.tmr_Obstaculos_spawn.Interval = 1200;
            this.tmr_Obstaculos_spawn.Tick += new System.EventHandler(this.Tmr_Obstaculos_Tick);
            // 
            // tmr_obstaculos_mueven
            // 
            this.tmr_obstaculos_mueven.Enabled = true;
            this.tmr_obstaculos_mueven.Tick += new System.EventHandler(this.Tmr_obstaculos_mueven_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(604, 348);
            this.Controls.Add(this.lbl_vidas);
            this.Controls.Add(this.pic_pasto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jumping Jack";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pic_pasto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_pasto;
        private System.Windows.Forms.Timer tmr_gravedad;
        private System.Windows.Forms.Label lbl_vidas;
        private System.Windows.Forms.Timer tmr_Salta;
        private System.Windows.Forms.Timer tmr_Obstaculos_spawn;
        private System.Windows.Forms.Timer tmr_obstaculos_mueven;
    }
}

