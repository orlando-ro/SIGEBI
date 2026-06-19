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

        // Relación para el módulo de Notificaciones
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

        // Relación para el módulo de Penalizaciones
        public virtual ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();

        // Regla de negocio del dominio (Rich Domain)
        public bool VerificarPenalizaciones()
        {
            // Retorna true si existe al menos una penalización que no esté pagada
            return Penalizaciones.Any(p => !p.Pagada);
        }

        //excepciones de negocio
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
