using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class PrestamoRequestDTO
    {
        [Required(ErrorMessage = "Debe especificar qué solicitud se va a aprobar.")]
        public int IdSolicitud { get; set; }
    }
}