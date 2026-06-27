using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class SolicitudRequestDTO
    {
        [Required(ErrorMessage = "El identificador del usuario es obligatorio.")]
        public string IdUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe enviar la lista de libros solicitados.")]
        [MinLength(1, ErrorMessage = "La solicitud debe contener al menos un libro (ISBN).")]
        public List<string> IsbnsLibros { get; set; } = new List<string>();
    }
}
