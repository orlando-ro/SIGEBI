using System.Collections.Generic;
using System.Linq;
using SIGEBI.Domain.Exceptions;


namespace SIGEBI.Domain.Entities
{
    public abstract class Usuario
    {
        public string IdUsuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";

        
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

        
        public virtual ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();

        
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        
        public bool VerificarPenalizaciones()
        {
            
            return Penalizaciones.Any(p => !p.Pagada);
        }

        
        public void ValidarElegibilidadParaPrestamo()
        {
            if (Estado != "Activo")
            {
                throw new NegocioExeption($"El usuario {Nombre} no se encuentra en estado Activo.");
            }

            if (VerificarPenalizaciones())
            {
                throw new NegocioExeption($"El usuario {Nombre} tiene penalizaciones activas y no puede solicitar préstamos.");
            }
        }
    }
}
