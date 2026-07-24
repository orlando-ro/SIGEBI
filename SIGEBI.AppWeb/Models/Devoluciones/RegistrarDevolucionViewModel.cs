using SIGEBI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Devoluciones
{
    public class RegistrarDevolucionViewModel
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la solicitud debe ser un número positivo.")]
        [Display(Name = "ID de la Solicitud")]

        public int IdPrestamo { get; set; }
        [Required(ErrorMessage = "Debe especificar la condición en la que se devuelve el libro.")]
        [Display(Name = "Condición Física del Libro")]
        public CondicionDevolucion CondicionLibro { get; set; }

        [Display(Name = "Observaciones Adicionales (Opcional)")]
        [MaxLength(250, ErrorMessage = "Las observaciones no pueden exceder los 250 caracteres.")]
        public string Observaciones { get; set; } = string.Empty;

    }
}
