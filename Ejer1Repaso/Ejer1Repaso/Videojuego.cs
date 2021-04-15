using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer1Repaso
{
    class Videojuego
    {
        public string Titulo
        {
            set; get;
        }
        public int Anho
        {
            set; get;
        }
        public enum Estilo
        {
            ARCADE = 1, VIDEOAVENTURA = 5, SHOOTEMUP = 4, ESTRATEGIA = 3, DEPORTIVO = 2
        }

        public Estilo EstiloJuego
        {
            set; get;
        }
    }
}
