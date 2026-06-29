using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class NotificacionResponseDTO
    {
        public int Id { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public bool Leida { get; set; }
    }
}