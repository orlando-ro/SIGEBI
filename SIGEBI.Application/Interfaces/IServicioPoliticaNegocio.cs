using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioPoliticaNegocio
    {
        int ObtenerLimitePrestamosPorTipoUsuario(Usuario usuario);

        void ValidarCapacidadPrestamo(
            Usuario usuario,
            int recursosSolicitados,
            IEnumerable<Prestamo> prestamosActivos,
            string contexto);

        DateTime CalcularFechaVencimiento(Usuario usuario, DateTime fechaInicio);
    }
}
