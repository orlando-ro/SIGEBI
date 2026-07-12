using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public record AuditoriaResponseDTO
    {
        public int IdAuditoria { get; set; }

        public int? IdResponsable { get; set; }

        public DateTime FechaHora { get; set; }

        public string Accion { get; set; } = string.Empty;

        public string EntidadAfectada { get; set; } = string.Empty;

        public string Detalles { get; set; } = string.Empty;

        public string FechaFormateada => FechaHora.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
