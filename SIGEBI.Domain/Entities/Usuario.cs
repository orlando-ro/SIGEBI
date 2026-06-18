using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public abstract class Usuario
    {
        public string IdUsuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo"; // Puede ser "Activo" o "Inactivo"

        // propiedad de navegación ( leugo se relaciona con la entidad Penalizacion)
        public virtual ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();

        // Regla de negocio del dominio
        public bool VerificarPenalizaciones()
        {
            // Retorna true si existe al menos una penalización que no esté pagada/resuelta
            return Penalizaciones.Any(p => !p.Pagada); // <--- Asumiendo que la clase Penalizacion tiene una propiedad "Pagada" de tipo bool que se desarrolla en la rama de desarrollo correspondiente
        }
    }
}