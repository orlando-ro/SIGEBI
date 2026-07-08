using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Domain.Entities
{
    public class Devolucion
    {
        public int IdDevolucion { get; set; }

        public DateTime FechaDevolucion { get; private set; }

        public CondicionDevolucion CondicionLibro { get; private set; }

        public string Observaciones { get; private set; } = string.Empty;

        public int IdPrestamo { get; private set; }

        public Prestamo? Prestamo { get; set; }

        public int IdBibliotecario { get; private set; }

        public Usuario? Bibliotecario { get; private set; }

        protected Devolucion() { }

        public Devolucion(
            int idPrestamo,
            int idBibliotecario,
            CondicionDevolucion condicionLibro,
            string observaciones = "")
        {
            if (idPrestamo <= 0)
                throw new NegocioExeption("La devolución debe estar asociada a un préstamo válido.");

            if (idBibliotecario <= 0)
                throw new NegocioExeption("La devolución debe estar asociada a un bibliotecario responsable.");

            IdPrestamo = idPrestamo;
            IdBibliotecario = idBibliotecario;
            CondicionLibro = condicionLibro;
            Observaciones = observaciones ?? string.Empty;
            FechaDevolucion = DateTime.Now;
        }

        public bool RequierePenalizacionPorDano()
        {
            return CondicionLibro == CondicionDevolucion.Dañado ||
                   CondicionLibro == CondicionDevolucion.Extraviado;
        }
    }
}