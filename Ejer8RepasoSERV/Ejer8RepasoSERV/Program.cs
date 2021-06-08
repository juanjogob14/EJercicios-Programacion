using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ejer8RepasoSERV
{
    class Program
    {
        public static bool bandera = true;

        static string Hora()
        {
            string hora = DateTime.Now.ToString("hh:mm:ss");
            return "Hora: " + hora;
        }

        static string Fecha()
        {
            string fecha = DateTime.Now.ToString("dd:MM:yyyy");
            return "Fecha: " + fecha;
        }

        static string FechaYHora()
        {
            string todo = "Hora: " + Hora() + " Fecha: " + Fecha();
            return todo;
        }
        static void Main(string[] args)
        {
            string mensajeInicial = "Selecciona una opcion: Hora, Fecha, Todo, Apagar";
            string cad;
            int port = 31416;

            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sock.Bind(ipe);
            }
            catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
            {
                bandera = false;
                Console.WriteLine("Error el puerto está en uso");
            }
            sock.Listen(1);

            while (bandera)
            {
                Socket scliente = sock.Accept();
                IPEndPoint ipEpClient = (IPEndPoint)scliente.RemoteEndPoint;
                Console.WriteLine("Usuario conectado en el puerto {0} "+ipEpClient.Port);

                using (NetworkStream ns = new NetworkStream(scliente))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    sw.WriteLine(mensajeInicial);
                    sw.Flush();

                    try
                    {
                        cad = sr.ReadLine();
                        if (cad!=null)
                        {
                            string mensaje = cad.ToUpper();

                            switch (mensaje)
                            {
                                case "Hora":
                                    sw.WriteLine(Hora());
                                    sw.Flush();
                                    break;

                                case "Fecha":
                                    sw.WriteLine(Fecha());
                                    sw.Flush();
                                    break;

                                case "Todo":
                                    sw.WriteLine(FechaYHora());
                                    sw.Flush();
                                    break;

                                case "Apagar":
                                    bandera = false;
                                    scliente.Close();
                                    break;

                                default:
                                    sw.WriteLine("Opción no válida");
                                    sw.Flush();
                                    break;
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    scliente.Close();
                }
                sock.Close();
            }
        }
    }
}
