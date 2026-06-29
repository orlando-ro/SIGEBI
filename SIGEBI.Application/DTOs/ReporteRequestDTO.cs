using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class ReporteRequestDTO
    {
        [Required(ErrorMessage = "Debe especificar el tipo de reporte (Ej: InventarioLibros, PrestamosVencidos).")]
        public string TipoReporte { get; set; } = string.Empty;

        [Required(ErrorMessage = "El identificador del usuario que solicita el reporte es obligatorio.")]
        public string IdUsuarioSolicitante { get; set; } = string.Empty;
    }
}
