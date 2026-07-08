using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public class LibroCatalogoResponseDTO
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public string NombreCategoria { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public int CopiasDisponibles { get; set; }
        public string? UrlImagen { get; set; }
    }
}