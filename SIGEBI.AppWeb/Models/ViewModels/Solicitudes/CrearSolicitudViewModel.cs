using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Solicitudes
{
    public class CrearSolicitudViewModel
    {
        [Required(ErrorMessage = "Debe ingresar al menos un ISBN.")]
        [Display(Name = "ISBN(s) de los libros (separados por coma)")] 
        public string IsbnsIngresados { get; set; } = string.Empty;
    }
}