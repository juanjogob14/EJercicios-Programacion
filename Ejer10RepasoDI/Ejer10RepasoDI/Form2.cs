using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer10RepasoDI
{
    public partial class Form2 : Form
    {
    

        Form1 f;
        public string rb1Selec, rb2Selec;
        public Form2(Form1 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < f.frikis.Count; i++)
            {
                Console.WriteLine(f.frikis[i]);

            }

            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);

            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                groupBox1.Controls[i].Text = Enum.GetNames(typeof(sFriki.eSexo))[i];
                groupBox2.Controls[i].Text = Enum.GetNames(typeof(sFriki.eSexo))[i];
            }

            for (int i = 0; i < Enum.GetNames(typeof(sFriki.eAficion)).Length; i++)
            {
                comboBox1.Items.Add(Enum.GetNames(typeof(sFriki.eAficion))[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Filter = "jpg files (*.jpg) |*.jpg| All files ()*.* | *.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op.FileName;
            }
        }

        private void RadioBotonesSeleccionadosSexo(object sender, EventArgs e)
        {
            RadioButton radiob1 = (RadioButton)sender;
            rb1Selec = radiob1.Text;
        }

        private void RadioBotonesSeleccionadosSexoOpuesto(object sender, EventArgs e)
        {
            RadioButton radiob2 = (RadioButton)sender;
            rb2Selec = radiob2.Text;
        }
    }
}
