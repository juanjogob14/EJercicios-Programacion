using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer1Repaso
{
    class Videojuegos
    {
        public List<Videojuego> juegos = new List<Videojuego>();
        Videojuego v = new Videojuego();

        public int Posicion(int anho)
        {
            int posicionInsercion = 0;

            for (int i = 0; i < juegos.Count; i++)
            {
                if (juegos[i].Anho > anho)
                {
                    posicionInsercion = juegos.IndexOf(juegos[i]);
                }
            }

            return posicionInsercion;
        }

        public bool Eliminar(int segundo , int primero=0)
        {
            if (primero >= 0 && primero <= juegos.Count-1 && segundo <= juegos.Count-1 && segundo >= 0 && segundo>=primero)
            {
                for (int j = segundo; j >= primero; j--)
                {
                
                    juegos.RemoveAt(j);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Videojuego> Busqueda(int estilo)
        {
            
            List<Videojuego> encontrados = new List<Videojuego>();
            
            for (int j = 0; j < juegos.Count(); j++)
            {
                if (Convert.ToInt32(juegos[j].EstiloJuego) == estilo)
                {
                    encontrados.Add(juegos[j]);
                }
            }

            return encontrados;
        }

    }
}
