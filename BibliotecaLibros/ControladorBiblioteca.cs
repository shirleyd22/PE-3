using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BibliotecaLibros
{
    public class ControladorBiblioteca
    {
        // se crea Diccionario para almacenar los libros utilizando el código como clave
        private Dictionary<string, Libro> libros;

        // Conjunto para almacenar los géneros sin repetir
        private HashSet<string> generos;

        // Mapa para relacionar el código con el título del libro
        private Dictionary<string, string> mapaTitulos;

        public ControladorBiblioteca()
        {
            libros = new Dictionary<string, Libro>();
            generos = new HashSet<string>();
            mapaTitulos = new Dictionary<string, string>();
        }

        public void RegistrarLibro(Libro libro)
        {
            Stopwatch tiempo = Stopwatch.StartNew();

            if (libros.ContainsKey(libro.Codigo))
            {
                Console.WriteLine("Ya existe un libro con ese código.");
                tiempo.Stop();
                Console.WriteLine("Tiempo de ejecución: " + tiempo.ElapsedTicks + " ticks");
                return;
            }

            libros.Add(libro.Codigo, libro);
            generos.Add(libro.Genero);
            mapaTitulos.Add(libro.Codigo, libro.Titulo);

            tiempo.Stop();

            Console.WriteLine("El libro fue registrado correctamente.");
            Console.WriteLine("Tiempo de ejecución: " + tiempo.ElapsedTicks + " ticks");
        }

        public void MostrarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No existen libros registrados.");
                return;
            }

            Console.WriteLine("\n===== LIBROS REGISTRADOS =====");

            foreach (Libro libro in libros.Values)
            {
                Console.WriteLine(libro);
            }
        }

        public void BuscarLibro(string codigo)
        {
            Stopwatch tiempo = Stopwatch.StartNew();

            if (libros.TryGetValue(codigo, out Libro libro))
            {
                tiempo.Stop();

                Console.WriteLine("\n===== LIBRO ENCONTRADO =====");
                Console.WriteLine(libro);
                Console.WriteLine("Tiempo de búsqueda: " + tiempo.ElapsedTicks + " ticks");
            }
            else
            {
                tiempo.Stop();

                Console.WriteLine("No se encontró ningún libro con ese código.");
                Console.WriteLine("Tiempo de búsqueda: " + tiempo.ElapsedTicks + " ticks");
            }
        }

        public void EliminarLibro(string codigo)
        {
            if (libros.ContainsKey(codigo))
            {
                libros.Remove(codigo);
                mapaTitulos.Remove(codigo);

                Console.WriteLine("Libro eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el libro.");
            }
        }

        public void ModificarLibro(string codigo)
        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            if (!libros.TryGetValue(codigo, out Libro libro))
            {
                Console.WriteLine("No se encontró el libro.");
                return;
            }
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL

            Console.Write("Nuevo título: ");
#pragma warning disable CS8601 // Posible asignación de referencia nula
            libro.Titulo = Console.ReadLine();
#pragma warning restore CS8601 // Posible asignación de referencia nula

            Console.Write("Nuevo autor: ");
            libro.Autor = Console.ReadLine();

            Console.Write("Nuevo género: ");
            libro.Genero = Console.ReadLine();

            Console.Write("Nuevo año de publicación: ");
            libro.Anio = int.Parse(Console.ReadLine());

            generos.Add(libro.Genero);
            mapaTitulos[codigo] = libro.Titulo;

            Console.WriteLine("Libro modificado correctamente.");
        }

        public void MostrarGeneros()
        {
            Console.WriteLine("\n===== GÉNEROS REGISTRADOS =====");

            if (generos.Count == 0)
            {
                Console.WriteLine("No hay géneros registrados.");
                return;
            }

            foreach (string genero in generos)
            {
                Console.WriteLine("- " + genero);
            }
        }

        public void MostrarReporte()
        {
            Console.WriteLine("\n========== REPORTE ==========");

            Console.WriteLine("Cantidad de libros: " + libros.Count);
            Console.WriteLine("Cantidad de géneros diferentes: " + generos.Count);
            Console.WriteLine("Cantidad de elementos en el mapa: " + mapaTitulos.Count);

            Console.WriteLine("\n--- Diccionario de libros ---");

            foreach (var elemento in libros)
            {
                Console.WriteLine(elemento.Key + " -> " + elemento.Value.Titulo);
            }

            Console.WriteLine("\n--- Conjunto de géneros ---");

            foreach (string genero in generos)
            {
                Console.WriteLine(genero);
            }

            Console.WriteLine("\n--- Mapa código-título ---");

            foreach (var elemento in mapaTitulos)
            {
                Console.WriteLine(elemento.Key + " -> " + elemento.Value);
            }
        }
    }
}