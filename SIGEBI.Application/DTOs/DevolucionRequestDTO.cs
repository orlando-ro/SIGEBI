using SIGEBI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class DevolucionRequestDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "El ID del préstamo es obligatorio y debe ser mayor a cero")]
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "Debe especificar la condición física del libro devuelto.")]
        public CondicionDevolucion CondicionLibro { get; set; }

        public string Observaciones { get; set; } = string.Empty;
    }
}