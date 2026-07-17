using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class ServicioPoliticaNegocio : IServicioPoliticaNegocio
    {
        public int ObtenerLimitePrestamosPorTipoUsuario(Usuario usuario)
        {
            if (usuario is Docente)
                return 5;

            if (usuario is Estudiante)
                return 3;

            return 2;
        }

        public void ValidarCapacidadPrestamo(
            Usuario usuario,
            int recursosSolicitados,
            IEnumerable<Prestamo> prestamosActivos,
            string contexto)
        {
            usuario.ValidarElegibilidadParaPrestamo();

            int limite = ObtenerLimitePrestamosPorTipoUsuario(usuario);

            if (limite <= 0)
            {
                var mensaje = contexto == "aprobar"
                    ? "Este tipo de usuario no está autorizado para recibir préstamos."
                    : "Este usuario no puede solicitar préstamos.";

                throw new NegocioExeption(mensaje);
            }

            int recursosActivos = prestamosActivos.SelectMany(p => p.EjemplaresAprestar).Count();

            if (recursosActivos + recursosSolicitados > limite)
            {
                var prefijo = contexto == "aprobar"
                    ? "No se puede aprobar la solicitud."
                    : "Excediste el límite de préstamos.";

                throw new NegocioExeption(
                    $"{prefijo} " +
                    $"Límite permitido: {limite}. " +
                    $"Recursos activos actuales: {recursosActivos}. " +
                    $"Libros solicitados: {recursosSolicitados}.");
            }
        }

        public DateTime CalcularFechaVencimiento(Usuario usuario, DateTime fechaInicio)
        {
            if (usuario is Docente)
                return fechaInicio.AddDays(14);

            return fechaInicio.AddDays(7);
        }
    }
}
