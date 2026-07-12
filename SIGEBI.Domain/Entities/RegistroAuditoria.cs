using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities
{
    public class RegistroAuditoria
    {
        public int IdAuditoria { get; private set; }

        public DateTime FechaHora { get; private set; }
        public int? IdResponsable { get; private set; }
        public string Accion { get; private set; } = string.Empty; // Ej: "Crear", "Actualizar", "Eliminar"
        public string EntidadAfectada { get; private set; } = string.Empty; // Ej: "Prestamo", "Libro"
        public string Detalles { get; private set; } = string.Empty; // Un JSON o texto con los cambios realizados


        protected RegistroAuditoria() { }

        
        public RegistroAuditoria(int? idResponsable, string accion, string entidadAfectada, string detalles)
        {
            if (idResponsable.HasValue && idResponsable <= 0)
                throw new NegocioExeption("El registro de auditoría debe estar asociado a un usuario.");

            if (string.IsNullOrWhiteSpace(accion))
                throw new NegocioExeption("Se debe especificar la acción auditada (Ej: Crear, Eliminar).");

            if (string.IsNullOrWhiteSpace(entidadAfectada))
                throw new NegocioExeption("Se debe especificar qué entidad fue afectada (Ej: Libro, Usuario).");

            IdResponsable = idResponsable;
            Accion = accion.Trim();
            EntidadAfectada = entidadAfectada.Trim();
            Detalles = detalles ?? string.Empty; 
            FechaHora = DateTime.Now;
        }
    }
}
