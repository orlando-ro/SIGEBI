using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class PenalizacionRequestDTO
    {
        [Required(ErrorMessage = "El ID de la penalización es obligatorio.")]
        public int IdPenalizacion { get; set; }

        [Required(ErrorMessage = "Debe especificar el método o motivo de resolución (Ej: Pago en efectivo, Exoneración).")]
        public string MotivoResolucion { get; set; } = string.Empty;
    }
}
