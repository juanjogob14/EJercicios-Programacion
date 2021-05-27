using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer10RepasoDI
{
    public partial class ValidateTextBox : UserControl
    {
        private Color ColorUsado = Color.Red;
        private bool Correcto = false;

      
        public ValidateTextBox()
        {
            InitializeComponent();
        }

        private void ValidateTextBox_Load(object sender, EventArgs e)
        {
            this.textBox1.Location = new Point(10, 10);
            this.Height = textBox1.Height + 20;
            textBox1.Width = this.Width - 20;
        }

        public string Texto
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {
                return textBox1.Text;
            }
        }

        public enum eTipo
        {
            NUMERICO, TEXTUAL
        }

        private eTipo tipo = eTipo.TEXTUAL;

        public eTipo Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen p = new Pen(ColorUsado);
            g.DrawRectangle(p, 5, 5, this.Width - 10, this.Height - 10);
        }

        private void comprobar()
        {
            Correcto = true;
            switch (tipo)
            {
                case eTipo.NUMERICO:
                    for (int i = 0; i < Texto.Length; i++)
                    {
                        if (Texto[i] >= '0' && Texto[i] <= '9')
                        {

                            if (Correcto)
                            {
                                ColorUsado = Color.Green;
                                Refresh();
                            }

                        }
                        else
                        {
                            Correcto = false;
                            ColorUsado = Color.Red;
                            Refresh();
                        }
                    }
                    break;
                case eTipo.TEXTUAL:
                    for (int i = 0; i < Texto.Length; i++)
                    {
                        if (Char.IsLetter(Texto[i]) || Char.IsWhiteSpace(Texto[i]))
                        {

                            if (Correcto)
                            {
                                ColorUsado = Color.Green;
                                Refresh();
                            }
                        }
                        else
                        {
                            Correcto = false;
                            ColorUsado = Color.Red;
                            Refresh();
                        }
                    }
                    break;

            }
        }

       
        [Category("Internal")]
        [Description("Enlaza con el evento text changed del textbox interno")]
        public event System.EventHandler CambiaTexto;

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            comprobar();
            CambiaTexto?.Invoke(this, new EventArgs());
        }
    }
}
