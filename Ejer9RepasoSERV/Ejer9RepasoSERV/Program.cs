using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejer9RepasoSERV
{
    class Program
    {
        static readonly object l = new object();
        static List<Jugador> listaJugadores = new List<Jugador>();
        static Random ran = new Random();
        static bool empieza = false, empiezaTimer = false;
        static int cont = 10, numeroMax = 0;

        static void Main(string[] args)
        {
            IPEndPoint ipendp = new IPEndPoint(IPAddress.Any, 31416);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Bind(ipendp);
                socket.Listen(3);

                while (!empieza)
                {
                    Socket socket2 = socket.Accept();

                    Thread hilo = new Thread(Juego);
                    hilo.Start(socket2);
                }
            }
            catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
            {
                Console.WriteLine("Error, puerto coupado");
            }
        }

        static void Juego(object socket)
        {
            Socket socketJuego = (Socket)socket;

            lock (l)
            {
                listaJugadores.Add(new Jugador(ran.Next(1, 21), socketJuego));
            }

            using (NetworkStream ns = new NetworkStream(socketJuego))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                lock (l)
                {
                    sw.WriteLine("Bienvenido al juego! \n " +
                        "Numero total de usuarios: "+listaJugadores.Count);
                }

                if (listaJugadores.Count >= 2 && !empiezaTimer)
                {
                    empiezaTimer = true;
                }
            }
        }

        static void timerJuego()
        {
            while (cont>0)
            {
                Thread.Sleep(1000);
                cont--;

                lock (l)
                {
                    for (int i = 0; i < listaJugadores.Count; i++)
                    {
                        try
                        {
                            using (NetworkStream ns = new NetworkStream(listaJugadores[i].SocketJugador))
                            using (StreamReader sr = new StreamReader(ns))
                            using (StreamWriter sw = new StreamWriter(ns))
                            {
                                sw.WriteLine("Tiempo restante: {0}", cont);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error");
                            listaJugadores.RemoveAt(i);
                        }
                    }
                }
            }

            lock (l)
            {
                for (int i = 0; i < listaJugadores.Count; i++)
                {
                    try
                    {
                        using (NetworkStream ns = new NetworkStream(listaJugadores[i].SocketJugador))
                        using (StreamReader sr = new StreamReader(ns))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {

                            if (listaJugadores[i].Numero >= numeroMax)
                            {
                                numeroMax = listaJugadores[i].Numero;
                            }
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                        listaJugadores.RemoveAt(i);
                    }
                }
            }

            lock (l)
            {
                for (int i = 0; i < listaJugadores.Count; i++)
                {
                    try
                    {
                        listaJugadores[i].SocketJugador.Close();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                        listaJugadores.RemoveAt(i);
                    }
                }
            }

            lock (l)
            {
                Console.WriteLine("Fin juego");
                listaJugadores.RemoveRange(0, listaJugadores.Count);
                cont = 5;
                empiezaTimer = false;
            }
        }
    }
}
