using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public class RechazoSolicitudRequestDTO
    {
        [Required (ErrorMessage = "Debe espesificar la solicitud sobre la cual va a realizar el rechaso")]
        public int idSolicitud { get; set; }

        [Required(ErrorMessage = "Debe espesificar el identificador del usuario a quien le va a realizar el rechazo")]
        public string MatriculaONumeroEmpleado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe ingresar el motivo del rechazo ")]

        public string MotivoRechazo { get; set; } = string.Empty;
    }
}
