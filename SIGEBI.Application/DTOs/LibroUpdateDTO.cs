using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public class LibroUpdateDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public int IdCategoria { get; set; }
    }
}
