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

        [Required(ErrorMessage = "El identificador del bibliotecario es obligatorio.")]
        public string IdBibliotecario { get; set; } = string.Empty;
    }
}
