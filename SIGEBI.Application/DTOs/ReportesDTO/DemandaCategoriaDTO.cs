using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DemandaCategoriaDTO
    {
        public string Categoria { get; set; } = string.Empty;

        public int CantidadSolicitada { get; set; }


    }
}
