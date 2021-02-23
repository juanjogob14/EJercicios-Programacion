using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing.Drawing2D;

namespace NuevosCompoenentes
{
    public partial class EtiquetaAviso : Control
    {

        private int offsetX, offsetY;

        public EtiquetaAviso()
        {
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int grosor = 0; //Grosor de las líneas de dibujo
             //Desplazamiento hacia abajo del texto
                             //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
                             // a la hora de dibujar

            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            SolidBrush sl = new SolidBrush(this.BackColor);
            LinearGradientBrush l = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, this.Height), this.ColorInicial, this.ColorFinal);
            Pen p = new Pen(l);

            offsetX = 0; //Desplazamiento a la derecha del texto
            offsetY = 0;

            if (this.Gradiente)
            {
                e.Graphics.FillRectangle(l, 0, 0, this.Width, this.Height);
            }
            else
            {
                e.Graphics.FillRectangle(sl, 0, 0, this.Width, this.Height);
            }
            
            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                    this.Font.Height, this.Font.Height);
                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor;
                    break;
                case eMarca.Cruz:
                    grosor = 5;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, this.Font.Height,
                    this.Font.Height);
                    g.DrawLine(lapiz, this.Font.Height, grosor, grosor,
                    this.Font.Height);
                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;
                case eMarca.Imagen:
                    if (imagenMarca!=null)
                    {
                        //grosor = 4;
                        //Width = (imagenMarca.Width * this.Font.Height) / imagenMarca.Height;
                        //Height = this.Font.Height;

                        offsetX = this.Font.Height + grosor;
                        offsetY = grosor;

                        g.DrawImage(imagenMarca, grosor, grosor, this.Font.Height, this.Font.Height);
                    }
                    break;
            }
            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY
            * 2);
            b.Dispose();
            
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        public enum eMarca
        {
            Nada,
            Cruz,
            Circulo,
            Imagen
        }

        private eMarca marca = eMarca.Nada;
        public eMarca Marca
        {
            set
            {
                
                marca = value;
                this.Refresh();
            }
            get { return marca; }
        }

        private Image imagenMarca;
        public Image ImagenMarca
        {
            set
            {
                this.imagenMarca = value;
            }
            get
            {
                return this.imagenMarca;
            }
        }

        public void UseHorizontalLinearGradients(PaintEventArgs e)
        {
            LinearGradientBrush l = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, this.Height), this.ColorInicial, this.ColorFinal);
            Pen p = new Pen(l, this.Height);
            e.Graphics.FillRectangle(l,0,0,this.Width, this.Height);
            this.Refresh();
        }

        private Boolean gradiente;
        public Boolean Gradiente
        {
            set
            {
                gradiente = value;

                if (value = true)
                {
                    HacerGradiente?.Invoke(this, new EventArgs());
                }
            }
            get
            {
                return gradiente;
            }
        }

        public static Bitmap Resize(Image image, int porCiento)
        {
            Bitmap imagen = (Bitmap)Bitmap.FromFile("C:\\Users\\Juanjo\\Desktop\\817e576bd6d9f9e48e8b55b7c922d894.jpg");

            float nPercent = (float)porCiento / 100;

            int destinoWidth = (int)(image.Width * nPercent); int destinoHeight = (int)(image.Height * nPercent);

            Bitmap imagen2 = new Bitmap(destinoWidth, destinoHeight);

            image.Dispose();

            return imagen2;
        }

        private Color colorInicial;

        public Color ColorInicial
        {
            set;get;
        }

        private Color colorFinal;

        public Color ColorFinal
        {
            set;get;
        }

        public event System.EventHandler HacerGradiente;

        public event System.EventHandler ClikEnMarca;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            //Console.WriteLine("Hola");

            if (e.X <= offsetX)
            {
                ClikEnMarca?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    
}
