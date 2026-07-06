using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public record ReporteResponseDTO
    {
        public int IdReporte { get; set; }

        public string TipoReporte { get; set; } = string.Empty;

        public DateTime FechaSolicitud { get; set; }

        public DateTime? FechaGeneracion { get; set; }

        public string Estado { get; set; } = string.Empty;

        public string RutaArchivo { get; set; } = string.Empty;

        public int IdUsuarioSolicitante { get; set; }

        public string NombreUsuarioSolicitante { get; set; } = string.Empty;

        public string? Matricula { get; set; }

        public string? NumeroEmpleado { get; set; }
    }
}
