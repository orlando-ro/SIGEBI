using System;
using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class RechazoSolicitudRequestDTO
    {
        [Required(ErrorMessage = "Debe especificar la solicitud sobre la cual va a realizar el rechazo.")]
        public int idSolicitud { get; set; }

        [Required(ErrorMessage = "Debe ingresar el motivo del rechazo.")]
        public string MotivoRechazo { get; set; } = string.Empty;
    }
}