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

        private void button2_Click(object sender, EventArgs e)
        {
            sFriki f1 = new sFriki(validateTextBox1.Texto, Convert.ToInt32(validateTextBox2.Texto), (sFriki.eAficion)(comboBox1.SelectedIndex), (sFriki.eSexo)Enum.Parse(typeof(sFriki.eSexo),rb1Selec,true), (sFriki.eSexo)Enum.Parse(typeof(sFriki.eSexo), rb2Selec, true), textBox1.Text);
            f.frikis.Add(f1);
            f.listBox1.Items.Add(f1);
            Console.WriteLine(rb1Selec);
        }


        private void RadioBotonesSeleccionados(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                rb1Selec = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                rb1Selec = radioButton2.Text;
            }

            if (radioButton3.Checked)
            {
                rb2Selec = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                rb2Selec = radioButton4.Text;
            }
        }
    }
}
