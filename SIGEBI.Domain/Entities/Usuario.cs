using System.Collections.Generic;
using System.Linq;

namespace SIGEBI.Domain.Entities
{
    public abstract class Usuario
    {
        public string IdUsuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";

        // Relación para el módulo de Notificaciones
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

        // Relación para el módulo de Penalizaciones
        public virtual ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();

        // Permite que un Usuario acceda a su lista de préstamos: usuario.Prestamos
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        // Regla de negocio del dominio (Rich Domain)
        public bool VerificarPenalizaciones()
        {
            // Retorna true si existe al menos una penalización que no esté pagada
            return Penalizaciones.Any(p => !p.Pagada);
        }
    }
}