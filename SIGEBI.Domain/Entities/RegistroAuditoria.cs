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
        public string IdUsuario { get; private set; }
        public string Accion { get; private set; } // Ej: "Crear", "Actualizar", "Eliminar"
        public string EntidadAfectada { get; private set; } // Ej: "Prestamo", "Libro"
        public string Detalles { get; private set; } // Un JSON o texto con los cambios realizados

        // Constructor vacío requerido por Entity Framework
        protected RegistroAuditoria() { }

        // Un registro de auditoría solo se puede CREAR. 
        // No hay métodos para editar, garantizando la inmutabilidad de la bitácora.
        public RegistroAuditoria(string idUsuario, string accion, string entidadAfectada, string detalles)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new NegocioExeption("El registro de auditoría debe estar asociado a un usuario.");

            if (string.IsNullOrWhiteSpace(accion))
                throw new NegocioExeption("Se debe especificar la acción auditada (Ej: Crear, Eliminar).");

            if (string.IsNullOrWhiteSpace(entidadAfectada))
                throw new NegocioExeption("Se debe especificar qué entidad fue afectada (Ej: Libro, Usuario).");

            IdUsuario = idUsuario;
            Accion = accion;
            EntidadAfectada = entidadAfectada;
            Detalles = detalles ?? string.Empty; // Los detalles pueden estar vacíos

            FechaHora = DateTime.Now;
        }
    }
}
