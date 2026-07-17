using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Helpers
{
    public static class MapeoExtensiones
    {
        public static string? ObtenerMatricula(Usuario? usuario)
            => usuario is Estudiante estudiante ? estudiante.Matricula : null;

        public static List<string> ObtenerTitulosLibros(IEnumerable<Ejemplar> ejemplares)
            => ejemplares.Where(e => e.Libro != null).Select(e => e.Libro!.Titulo).ToList();

        public static List<string> ObtenerIsbns(IEnumerable<Ejemplar> ejemplares)
            => ejemplares.Select(e => e.ISBN).ToList();
    }
}
