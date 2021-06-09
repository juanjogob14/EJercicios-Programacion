using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ejer9RepasoSERV
{
    class Jugador
    {
        public int Numero { set; get; }
        public Socket SocketJugador { set; get; }

        public Jugador(int numero, Socket socketJugador)
        {
            this.Numero = numero;
            this.SocketJugador = socketJugador;
        }

    }
}
