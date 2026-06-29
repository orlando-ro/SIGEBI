using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class AuditoriaResponseDTO
    {
        public int IdRegistro { get; set; }
        public string IdUsuarioActor { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string TipoAccion { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;
        public string EntidadAfectada { get; set; } = string.Empty;
        public string DetallesAdicionales { get; set; } = string.Empty;

        
        public string FechaFormateada => FechaHora.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
