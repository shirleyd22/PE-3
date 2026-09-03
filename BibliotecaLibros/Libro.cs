namespace BibliotecaLibros
{
    public class Libro
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Anio { get; set; }

        public Libro(string codigo, string titulo, string autor, string genero, int anio)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Anio = anio;
        }
        public override string ToString()
        {
            return $"Código: {Codigo} | Título: {Titulo} | Autor: {Autor} | Género: {Genero} | Año: {Anio}"; 
        }
    }
}