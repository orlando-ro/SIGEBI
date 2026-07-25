using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Solicitudes
{
    public class RechazarSolicitudViewModel
    {
        [Required(ErrorMessage = "Debe especificar el número de solicitud.")]
        [Display(Name = "Número de Solicitud (ID)")]
        public int IdSolicitud { get; set; }

        [Required(ErrorMessage = "Debe especificar el motivo del rechazo.")]
        [Display(Name = "Motivo del Rechazo")]
        [MinLength(5, ErrorMessage = "El motivo debe ser más descriptivo.")]
        public string MotivoRechazo { get; set; } = string.Empty;
    }
}