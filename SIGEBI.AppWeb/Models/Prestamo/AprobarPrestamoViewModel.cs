using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Prestamos
{
    public class AprobarPrestamoViewModel
    {
        [Required(ErrorMessage = "Debe especificar el número de solicitud a aprobar.")]
        [Display(Name = "Número de Solicitud (ID)")]
        public int IdSolicitud { get; set; }
    }
}