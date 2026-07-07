using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetalleInventarioDTO
    {
        public string Codigo { get; set; } = string.Empty;

        public string Titulo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

    }
}
