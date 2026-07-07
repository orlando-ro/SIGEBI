using SIGEBI.Application.DTOs.ReportesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public record ReporteCatalogoResponseDTO
    {
        public List<RecursoMasSolicitadosDTO> RecursosMasSolicitados { get; set; } = [];

        public List<DemandaCategoriaDTO> DemandaCategorias { get; set; } = [];

    }
}
