using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.DTOs.Penalizaciones
{
    public class PenalizacionRequestDTO
    {
        [JsonPropertyName("matriculaONumeroEmpleado")]
        public string MatriculaONumeroEmpleado { get; set; } = string.Empty;

        [JsonPropertyName("motivoResolucion")]
        public string MotivoResolucion { get; set; } = string.Empty;
    }
}
