namespace Snake
{
    partial class Snake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snake));
            this.pic_game = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.img_lista = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_game)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_game
            // 
            this.pic_game.Location = new System.Drawing.Point(12, 12);
            this.pic_game.Name = "pic_game";
            this.pic_game.Size = new System.Drawing.Size(420, 420);
            this.pic_game.TabIndex = 0;
            this.pic_game.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // img_lista
            // 
            this.img_lista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_lista.ImageStream")));
            this.img_lista.TransparentColor = System.Drawing.Color.Transparent;
            this.img_lista.Images.SetKeyName(0, "manzana.png");
            this.img_lista.Images.SetKeyName(1, "rasp.png");
            this.img_lista.Images.SetKeyName(2, "anana.png");
            this.img_lista.Images.SetKeyName(3, "frutilla.png");
            this.img_lista.Images.SetKeyName(4, "snake_body.png");
            this.img_lista.Images.SetKeyName(5, "snake_head.png");
            this.img_lista.Images.SetKeyName(6, "pared.png");
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 439);
            this.Controls.Add(this.pic_game);
            this.MaximizeBox = false;
            this.Name = "Snake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Snake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pic_game)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_game;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ImageList img_lista;
    }
}

