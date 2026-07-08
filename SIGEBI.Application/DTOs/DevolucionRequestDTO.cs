using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class DevolucionRequestDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "El ID del préstamo es obligatorio y debe ser mayor a cero")]
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "Debe especificar la condición física del libro devuelto.")]
        public CondicionDevolucion CondicionLibro { get; set; }

        [Required(ErrorMessage = "Debe espesificar el identificador de la persona a quien pertenece la devolucion")]
        public string MatriculaONumeroEmpleadoBibliotecario { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;
    }
}
