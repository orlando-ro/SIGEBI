using System;

namespace SIGEBI.AppWeb.Models.Auditoria
{
    public class AuditoriaItemViewModel
    {
        public int IdAuditoria { get; set; }
        public int? IdResponsable { get; set; }
        public DateTime FechaHora { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string EntidadAfectada { get; set; } = string.Empty;
        public string Detalles { get; set; } = string.Empty;

        // Propiedad calculada para mostrar la fecha de forma amigable
        public string FechaFormateada => FechaHora.ToString("dd/MMM/yyyy hh:mm tt");
    }
}