using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Domain.Entities
{
    public class Penalizacion
    {
        public int IdPenalizacion { get; set; }

        public double Monto { get; private set; }

        public string Motivo { get; private set; } = string.Empty;

        public DateTime FechaEmision { get; private set; }

        public bool Pagada { get; private set; }

        public int IdUsuario { get; private set; }

        public Usuario? Usuario { get; set; }

        public int? IdPrestamo { get; private set; }

        public Prestamo? Prestamo { get; private set; }

        public DateTime? FechaResolucion { get; private set; }

        public int? IdUsuarioResolutor { get; private set; }

        public Usuario? UsuarioResolutor { get; private set; }

        public string MotivoResolucion { get; private set; } = string.Empty;

        protected Penalizacion() { }

        public Penalizacion(
            int idUsuario,
            double monto,
            string motivo,
            int? idPrestamo = null)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("La penalización debe estar asociada a un usuario.");

            if (monto <= 0)
                throw new NegocioExeption("El monto de la penalización debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(motivo))
                throw new NegocioExeption("Se debe especificar el motivo de la penalización.");

            if (idPrestamo.HasValue && idPrestamo.Value <= 0)
                throw new NegocioExeption("El préstamo asociado a la penalización no es válido.");

            IdUsuario = idUsuario;
            Monto = monto;
            Motivo = motivo;
            IdPrestamo = idPrestamo;
            FechaEmision = DateTime.Now;
            Pagada = false;
        }

        public void MarcarComoPagada(int idUsuarioResolutor, string motivoResolucion)
        {
            if (Pagada)
                throw new NegocioExeption("Esta penalización ya se encuentra pagada o resuelta.");

            if (idUsuarioResolutor <= 0)
                throw new NegocioExeption("Debe indicar el usuario responsable de resolver la penalización.");

            if (string.IsNullOrWhiteSpace(motivoResolucion))
                throw new NegocioExeption("Debe especificar el motivo o método de resolución.");

            Pagada = true;
            IdUsuarioResolutor = idUsuarioResolutor;
            MotivoResolucion = motivoResolucion;
            FechaResolucion = DateTime.Now;
        }
    }
}