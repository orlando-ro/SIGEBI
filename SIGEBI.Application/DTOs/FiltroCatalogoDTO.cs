using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public class FiltroCatalogoDTO
    {
        public string? Titulo { get; set; }
        public string? NombreAutor { get; set; }
        public int? IdCategoria { get; set; }
        public bool SoloDisponibles { get; set; } = false;
    }
}
