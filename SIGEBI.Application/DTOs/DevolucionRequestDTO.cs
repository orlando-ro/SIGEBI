using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class DevolucionRequestDTO
    {
        [Required(ErrorMessage = "El ID del préstamo es obligatorio.")]
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "Debe especificar la condición física del libro devuelto.")]
        public string CondicionLibro { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;
    }
}
