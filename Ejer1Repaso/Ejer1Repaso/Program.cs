using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer1Repaso
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion=0;
            Videojuegos v = new Videojuegos();

            Videojuego j1 = new Videojuego();
            j1.Titulo = "Need for speed";
            j1.Anho = 2001;
            j1.EstiloJuego = Videojuego.Estilo.DEPORTIVO;

            Videojuego j2 = new Videojuego();
            j2.Titulo = "Crash Bandicoot";
            j2.Anho = 1995;
            j2.EstiloJuego = Videojuego.Estilo.ARCADE;

            Videojuego j3 = new Videojuego();
            j3.Titulo = "GTA";
            j3.Anho = 2004;
            j3.EstiloJuego = Videojuego.Estilo.VIDEOAVENTURA;

            Videojuego j4 = new Videojuego();
            j4.Titulo = "Parkitect";
            j4.Anho = 2016;
            j4.EstiloJuego = Videojuego.Estilo.ESTRATEGIA;

            v.juegos.Add(j1);
            v.juegos.Add(j2);
            v.juegos.Add(j3);
            v.juegos.Add(j4);

            v.juegos = v.juegos.OrderBy(Videojuegos => Videojuegos.Anho).ToList();
                do
                {
                    try
                    {
                        Console.WriteLine("Selecciona una opción: \n" +
                    "1. Insertar juego nuevo \n" +
                    "2. Eliminar juego \n" +
                    "3. Visualizar juegos \n" +
                    "4. Visualizar juegos según estilo \n" +
                    "5. Modificar videojuego \n" +
                    "6. Salir del programa \n");
                        opcion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Elija una opción correcta");
                       
                    }
                    

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("¿Nombre del juego?");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("¿Año del juego?");
                            int anho = Convert.ToInt32(Console.ReadLine());

                            Videojuego juegoNuevo = new Videojuego();
                            juegoNuevo.Titulo = nombre;
                            juegoNuevo.Anho = anho;
                            juegoNuevo.EstiloJuego = (Videojuego.Estilo)(PedirGenero());
                            v.juegos.Insert(v.Posicion(anho), juegoNuevo);
                            v.juegos = v.juegos.OrderBy(Videojuegos => Videojuegos.Anho).ToList();

                            break;

                        case 2:
                            Console.WriteLine("¿Desde que posición hasta que posición quieres borrar?");
                            Console.WriteLine("Primera posición:");
                            int primero = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Segunda posición:");
                            int segundo = Convert.ToInt32(Console.ReadLine());
                            if (v.Eliminar(segundo, primero))
                            {
                                Console.WriteLine("Borrado con éxito");
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }


                            break;
                        case 3:
                            string resultado;
                            for (int i = 0; i < v.juegos.Count; i++)
                            {
                                if (v.juegos[i].Titulo.Length > 8)
                                {
                                    resultado = v.juegos[i].Titulo.Substring(0, 7) + "...";
                                }
                                else
                                {
                                    resultado = v.juegos[i].Titulo;
                                }

                                Console.WriteLine("{0,3} {1,10} {2,15}", i, resultado, v.juegos[i].EstiloJuego);
                            }
                            Console.ReadLine();

                            break;

                        case 4:
                            int valor = PedirGenero();
                            string resultado1;

                            for (int i = 0; i < v.Busqueda(valor).Count; i++)
                            {
                                if (v.Busqueda(valor)[i].Titulo.Length > 8)
                                {

                                    resultado1 = v.Busqueda(valor)[i].Titulo.Substring(0, 7) + "...";
                                }
                                else
                                {
                                    resultado1 = v.Busqueda(valor)[i].Titulo;
                                }
                                Console.WriteLine("{0,3} {1,10} {2,15}", i, resultado1, v.Busqueda(valor)[i].EstiloJuego);
                            }

                            break;

                        case 5:
                            Console.WriteLine("¿Que posición quieres actualizar?");
                            int indice = Convert.ToInt32(Console.ReadLine());
                            v.juegos.RemoveAt(indice);
                            Console.WriteLine("Introduzca los nuevos datos del juego: \n" +
                                "Nombre: ");
                            string nombreNuevo = Console.ReadLine();
                            Console.WriteLine("Año: ");
                            int anhoNuevo = Convert.ToInt32(Console.ReadLine());
                            Videojuego juegoActualizado = new Videojuego();
                            juegoActualizado.Titulo = nombreNuevo;
                            juegoActualizado.Anho = anhoNuevo;
                            juegoActualizado.EstiloJuego = (Videojuego.Estilo)(PedirGenero());
                            v.juegos.Add(juegoActualizado);
                            v.juegos = v.juegos.OrderBy(Videojuegos => Videojuegos.Anho).ToList();

                            break;

                        case 6:
                            Console.WriteLine("Gracias por su tiempo");
                            break;
                        default:
                            break;
                    }
                } while (opcion != 6);
            
        }

        static int PedirGenero()
        {
            Console.WriteLine("¿Genero del juego?\n" +
                           "1. " + Videojuego.Estilo.ARCADE +
                           "\n2. " + Videojuego.Estilo.DEPORTIVO +
                           "\n3. " + Videojuego.Estilo.ESTRATEGIA +
                           "\n4. " + Videojuego.Estilo.SHOOTEMUP +
                           "\n5. " + Videojuego.Estilo.VIDEOAVENTURA);
            int genero = Convert.ToInt32(Console.ReadLine());

            return genero;
        }
    }
}
