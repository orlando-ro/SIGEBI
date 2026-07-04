using SIGEBI.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;


namespace SIGEBI.Domain.Entities
{
    public abstract class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
        public string Password { get; set; } = string.Empty;
        public string? NumeroEmpleado { get; set; } 


        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

        
        public virtual ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();

        
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public virtual ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();


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
