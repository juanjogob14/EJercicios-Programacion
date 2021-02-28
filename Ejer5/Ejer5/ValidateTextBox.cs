using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer5
{
    public partial class ValidateTextBox : UserControl
    {
        private bool correcto;
        Color color = Color.Red;

        public bool Correcto
        {
            set
            {
                correcto = value;
                Refresh();
            }
            get
            {
                return correcto;
            }
        }

        private string texto;

        public string Texto
        {
            set
            {
                textBox1.Text = value;
                Refresh();
            } 
            get
            {
                return textBox1.Text;
            }
        } 

        private Boolean multilinea;

        public Boolean Multilinea
        {
            set
            {
                textBox1.Multiline = value ;
                Refresh();
            } 
            get
            {
                return textBox1.Multiline;
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
                if (Enum.IsDefined(typeof(eTipo),value))
                {
                    tipo = value;
                    //cambiaTipo();
                    Refresh();
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return tipo;
            }
        }

        private void cambiaTipo()
        {
            Correcto = true;
            switch (tipo)
            {
                case eTipo.NUMERICO:
                    for (int i = 0; i < Texto.Length; i++)
                    {
                        if (Texto[i] >= 48 && Texto[i] <= 57 || Texto[i]==10 || Texto[i] == 13)
                        {

                            if (Correcto)
                            {
                                color = Color.Green;
                                Refresh();
                            }
                            
                        }
                        else
                        {
                            Correcto = false;
                            color = Color.Red;
                            Refresh();
                        }
                    }
                    break;
                case eTipo.TEXTUAL:
                    for (int i = 0; i < Texto.Length; i++)
                    {
                        if (Texto[i] >= 65 && Texto[i]<=90 || Texto[i]>=97 && Texto[i]<=122 || Texto[i] == 32 || Texto[i] == 10 || Texto[i] == 13)
                        {

                            if (Correcto)
                            {
                                color = Color.Green;
                                Refresh();
                            }
                        }
                        else
                        {
                            Correcto = false;
                            color = Color.Red;
                            Refresh();
                        }
                    }
                    break;
                    
            }
        }

        public ValidateTextBox()
        {
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            this.Height = textBox1.Height + 20;
            textBox1.Width = this.Width - 20;
            
            SolidBrush b = new SolidBrush(color);
            g.FillRectangle(b, 5, 5, this.Width - 5, this.Height - 5);
               
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cambiaTipo();
        }
    }
}
