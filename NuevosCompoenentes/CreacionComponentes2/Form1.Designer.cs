namespace CreacionComponentes2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.etiquetaAviso3 = new NuevosCompoenentes.EtiquetaAviso();
            this.etiquetaAviso2 = new NuevosCompoenentes.EtiquetaAviso();
            this.SuspendLayout();
            // 
            // etiquetaAviso3
            // 
            this.etiquetaAviso3.ColorFinal = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.etiquetaAviso3.ColorInicial = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.etiquetaAviso3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaAviso3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.etiquetaAviso3.Gradiente = true;
            this.etiquetaAviso3.ImagenMarca = ((System.Drawing.Image)(resources.GetObject("etiquetaAviso3.ImagenMarca")));
            this.etiquetaAviso3.Location = new System.Drawing.Point(89, 84);
            this.etiquetaAviso3.Marca = NuevosCompoenentes.EtiquetaAviso.eMarca.Imagen;
            this.etiquetaAviso3.Name = "etiquetaAviso3";
            this.etiquetaAviso3.Size = new System.Drawing.Size(72, 25);
            this.etiquetaAviso3.TabIndex = 1;
            this.etiquetaAviso3.Text = "Hola";
            this.etiquetaAviso3.HacerGradiente += new System.EventHandler(this.EtiquetaAviso3_HacerGradiente);
            this.etiquetaAviso3.ClikEnMarca += new System.EventHandler(this.etiquetaAviso3_ClikEnMarca);
            this.etiquetaAviso3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EtiquetaAviso3_MouseDown);
            // 
            // etiquetaAviso2
            // 
            this.etiquetaAviso2.ColorFinal = System.Drawing.Color.Empty;
            this.etiquetaAviso2.ColorInicial = System.Drawing.Color.Empty;
            this.etiquetaAviso2.Gradiente = false;
            this.etiquetaAviso2.ImagenMarca = null;
            this.etiquetaAviso2.Location = new System.Drawing.Point(25, 12);
            this.etiquetaAviso2.Marca = NuevosCompoenentes.EtiquetaAviso.eMarca.Circulo;
            this.etiquetaAviso2.Name = "etiquetaAviso2";
            this.etiquetaAviso2.Size = new System.Drawing.Size(0, 0);
            this.etiquetaAviso2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.etiquetaAviso3);
            this.Controls.Add(this.etiquetaAviso2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NuevosCompoenentes.EtiquetaAviso etiquetaAviso1;
        private NuevosCompoenentes.EtiquetaAviso etiquetaAviso2;
        private NuevosCompoenentes.EtiquetaAviso etiquetaAviso3;
    }
}

