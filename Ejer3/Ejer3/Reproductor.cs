using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3
{
    public partial class Reproductor : UserControl
    {
        Boolean play = true;
        private Boolean mostrando = true;

        public Boolean Mostrando
        {
            set
            {
                mostrando = value;
                Refresh();
            }
            get
            {
                return mostrando;
            }
        }
        public Reproductor()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (play)
            {
                ClickEn?.Invoke(this, EventArgs.Empty);
                Mostrando = true;
                //button1.Text = "Pause";
                button1.Image = Image.FromFile("C:\\Users\\Juanjo\\Desktop\\pause3.png");
                play = false;
            }
            else
            {
                play = true;
                ClickEn2?.Invoke(this, EventArgs.Empty);
                //button1.Text = "Play";
                button1.Image = Image.FromFile("C:\\Users\\Juanjo\\Desktop\\play3.png");
            }
        }

        private int xx = 0, yy = 0;

        public int XX
        {
            set
            {
                xx = value;
                if (xx > 99)
                {
                    xx = 0;
                }
            }
            get
            {
                return xx;
            }
        }

        public int YY
        {
            set
            {
                yy = value;
                if (yy>59)
                {
                    yy = yy / 60;
                    DesbordaTiempo?.Invoke(this, new EventArgs());
                }
            }
            get
            {
                return yy;
            }
        }

        private void label1_Text(object sender, EventArgs e)
        {
            label1.Text = String.Format("{0,2:D2} : {1,2:D2}", XX, YY);
        }

        [Category("Cambia la propiedad")]
        [Description("Si la propiedad YY llega a 59 sumará uno en la propiedad XX")]
        public event System.EventHandler DesbordaTiempo;

        public event System.EventHandler ClickEn;
        public event System.EventHandler ClickEn2;
    }
}
