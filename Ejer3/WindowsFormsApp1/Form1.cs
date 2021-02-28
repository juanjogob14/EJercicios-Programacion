using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog fbd;
        private string nombreCarpeta;
        string[] images;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
        }

        private void reproductor1_DesbordaTiempo(object sender, EventArgs e)
        {
            Console.WriteLine("Estamos en el evento desborda tiempo");
            reproductor1.XX++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reproductor1.YY++;
            
            reproductor1.label1.Text = String.Format("{0,2:D2} : {1,2:D2}", reproductor1.XX, reproductor1.YY);
            try
            {
                if (i > images.Length - 1)
                {
                    i = 0;
                }
                if (i <= images.Length)
                {
                    pictureBox1.Image = Image.FromFile(images[i]);
                }

                i++;
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("Error");
            }
            

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                nombreCarpeta = fbd.SelectedPath;
                if (Directory.Exists(nombreCarpeta)) 
                {
                    images = Directory.GetFiles(nombreCarpeta, "*.jpg");
                    
                }
            }
        }

        private void reproductor1_ClickEn(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void reproductor1_ClickEn2(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
