using System;

namespace BibliotecaLibros
{
    class Program
    {
        static void Main(string[] args)
        {
            BibliotecaLibros.ControladorBiblioteca biblioteca =new BibliotecaLibros.ControladorBiblioteca();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("        SISTEMA DE BIBLIOTECA");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Mostrar libros");
                Console.WriteLine("3. Buscar libro por código");
                Console.WriteLine("4. Modificar libro");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("6. Mostrar géneros");
                Console.WriteLine("7. Mostrar reporte");
                Console.WriteLine("8. Salir");
                Console.WriteLine("======================================");
                Console.Write("Por favor, seleccione una opción: ");

                int.TryParse(Console.ReadLine(), out opcion);

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RegistrarLibro(biblioteca);
                        break;

                    case 2:
                        biblioteca.MostrarLibros();
                        Pausar();
                        break;

                    case 3:
                        Console.Write("Ingrese el código del libro: ");
                        string codigoBuscar = Console.ReadLine();

                        biblioteca.BuscarLibro(codigoBuscar);
                        Pausar();
                        break;

                    case 4:
                        Console.Write("Ingrese el código del libro que desea modificar: ");
                        string codigoModificar = Console.ReadLine();

                        biblioteca.ModificarLibro(codigoModificar);
                        Pausar();
                        break;

                    case 5:
                        Console.Write("Ingrese el código del libro que desea eliminar: ");
                        string codigoEliminar = Console.ReadLine();

                        biblioteca.EliminarLibro(codigoEliminar);
                        Pausar();
                        break;

                    case 6:
                        biblioteca.MostrarGeneros();
                        Pausar();
                        break;

                    case 7:
                        biblioteca.MostrarReporte();
                        Pausar();
                        break;

                    case 8:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }

            } while (opcion != 8);
        }

        static void RegistrarLibro(ControladorBiblioteca biblioteca)
        {
            Console.WriteLine("========== REGISTRO DE LIBRO ==========");

            Console.Write("Código: ");
            string codigo = Console.ReadLine();

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Género: ");
            string genero = Console.ReadLine();

            Console.Write("Año de publicación: ");
            int.TryParse(Console.ReadLine(), out int anio);

            Libro libro = new Libro(
                codigo,
                titulo,
                autor,
                genero,
                anio
            );

            biblioteca.RegistrarLibro(libro);

            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}