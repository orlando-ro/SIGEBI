using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class PenalizacionRequestDTO
    {
        [Required(ErrorMessage = "La matricula de la persona a penalizar es obligatoria.")]
        public string MatriculaONumeroEmpleado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar el método o motivo de resolución (Ej: Pago en efectivo, Exoneración).")]
        public string MotivoResolucion { get; set; } = string.Empty;
    }
}
