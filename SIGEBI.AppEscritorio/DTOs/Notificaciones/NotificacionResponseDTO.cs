using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Models
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