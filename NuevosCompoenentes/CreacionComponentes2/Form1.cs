using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreacionComponentes2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EtiquetaAviso3_Click(object sender, EventArgs e)
        {

        }

        private void EtiquetaAviso3_HacerGradiente(object sender, EventArgs e)
        {
            etiquetaAviso3.UseHorizontalLinearGradients((PaintEventArgs)e);
        }

        private void EtiquetaAviso3_MouseDown(object sender, MouseEventArgs e)
        {
               
        }

        private void etiquetaAviso3_ClikEnMarca(object sender, EventArgs e)
        {
            Console.WriteLine("hola");
        }
    }
}
