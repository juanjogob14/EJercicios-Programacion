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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<sFriki> frikis = new List<sFriki>();
        public List<sFriki> parejas = new List<sFriki>();
        static string texto = "Ejercicio10";
        int contador = 0, offsetx , offsety;
        ToolTip tp = new ToolTip();

        
        private void Form1_Load(object sender, EventArgs e)
        {
            sFriki friki1 = new sFriki("Juanjo", 21, sFriki.eAficion.MANGA, sFriki.eSexo.HOMBRE, sFriki.eSexo.MUJER, "C:\\Users\\Juanjo\\Desktop\\foto1.jpg");
            sFriki friki2 = new sFriki("Marcos", 20, sFriki.eAficion.FANTASIA, sFriki.eSexo.HOMBRE, sFriki.eSexo.MUJER, "C:\\Users\\Juanjo\\Desktop\\foto2.png");
            sFriki friki5 = new sFriki("Aldara", 20, sFriki.eAficion.FANTASIA, sFriki.eSexo.MUJER, sFriki.eSexo.HOMBRE, "C:\\Users\\Juanjo\\Desktop\\foto2.png");
            sFriki friki3 = new sFriki("Manuel", 22, sFriki.eAficion.TECNOLOGIA, sFriki.eSexo.HOMBRE, sFriki.eSexo.MUJER, "C:\\Users\\Juanjo\\Desktop\\foto3.png");
            sFriki friki4 = new sFriki("Pamela", 18, sFriki.eAficion.MANGA, sFriki.eSexo.MUJER, sFriki.eSexo.HOMBRE, "C:\\Users\\Juanjo\\Desktop\\foto3.png");
            sFriki friki6 = new sFriki("Pamela2", 18, sFriki.eAficion.MANGA, sFriki.eSexo.MUJER, sFriki.eSexo.HOMBRE, "C:\\Users\\Juanjo\\Desktop\\foto3.png");
            sFriki friki7 = new sFriki("Pamela3", 18, sFriki.eAficion.MANGA, sFriki.eSexo.MUJER, sFriki.eSexo.HOMBRE, "C:\\Users\\Juanjo\\Desktop\\foto3.png");
            sFriki friki8 = new sFriki("Pamela4", 18, sFriki.eAficion.MANGA, sFriki.eSexo.MUJER, sFriki.eSexo.HOMBRE, "C:\\Users\\Juanjo\\Desktop\\foto3.png");
            frikis.Add(friki1);
            frikis.Add(friki2);
            frikis.Add(friki3);
            frikis.Add(friki4);
            frikis.Add(friki5);
            frikis.Add(friki6);
            frikis.Add(friki7);
            frikis.Add(friki8);
            for (int i = 0; i < frikis.Count; i++)
            {
                listBox1.Items.Add(frikis[i]);
            }
            listBoxparejas.DataSource = parejas;
            this.Text = "";
            timer1.Start();
            
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres borrar estos elementos?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (listBox1.Items.Count > 0)
                {
                    for (int i = listBox1.SelectedIndices.Count - 1 ; i >= 0; i--)
                    {
                        Console.WriteLine(listBox1.SelectedIndices[i]);
                        frikis.RemoveAt(listBox1.SelectedIndices[i]);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                    }

                }
            }

        }

        private void BorrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnBorrar_Click(sender, e);
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juanjo Goberna", "Autor",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.ShowDialog();
        }

        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnNuevo_Click(sender, e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            offsety = 0;
            offsetx = 0;
            panel1.Controls.Clear();
            int comparar = listBox1.Items.Count;
            parejas.Clear();

            for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
            {
                if (listBox1.SelectedIndices[i] <= comparar)
                {
                    comparar = listBox1.SelectedIndices[i];
                    lbldetalles.Text = String.Format("Nombre: {0} \n Edad: {1} \n Aficion: {2} \n Sexo: {3} \n Sexo opuesto: {4}",frikis[comparar].Nombre,Convert.ToInt32(frikis[comparar].Edad),frikis[comparar].AficionPrincipal, frikis[comparar].Sexo, frikis[comparar].SexoOpuesto);
                    
                    for (int j = 0; j < listBox1.Items.Count; j++)
                    {
                        if ((frikis[comparar].AficionPrincipal == frikis[j].AficionPrincipal) && (frikis[comparar].Sexo == frikis[j].SexoOpuesto) && (frikis[comparar].SexoOpuesto != frikis[j].SexoOpuesto))
                        {
                            parejas.Add(frikis[j]);
                            listBoxparejas.DataSource = null;
                            listBoxparejas.DataSource = parejas;
                        }
                        else
                        {
                            listBoxparejas.DataSource = null;
                            listBoxparejas.DataSource = parejas;
                        }
                    }

                    for (int k = 0; k < parejas.Count(); k++)
                    {
                        if (k % 3 == 0 && k != 0)
                        {
                            offsetx = 90;
                            offsety += 90;
                        }
                        else
                        {
                            offsetx += 90;
                        }
                        PictureBox p = new PictureBox();
                        panel1.Controls.Add(p);
                        p.Image = Image.FromFile(parejas[k].Foto);
                        tp.SetToolTip(p, parejas[k].Nombre);
                        p.Height = 80;
                        p.Width = 80;
                        p.Location = new Point(offsetx, offsety);
                        p.SizeMode = PictureBoxSizeMode.StretchImage;

                    }

                    try
                    {
                        pictureBoxFoto.Image = Image.FromFile(frikis[comparar].Foto);
                        tp.SetToolTip(pictureBoxFoto, frikis[comparar].Nombre);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                    }
                    tp.SetToolTip(pictureBoxFoto, frikis[comparar].Nombre);
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (contador == 0)
            {
                this.Text = "";
            }

            if (contador == texto.Length)
            {
                contador = 0;
            }
            else
            {
                this.Text = this.Text.Insert(contador, texto[contador]+"");
                contador++;

            }

        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
