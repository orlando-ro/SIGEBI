using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Solicitudes
{
    public class SolicitudResponseDTO
    {
        [JsonPropertyName("idSolicitud")] 
        public int IdSolicitud { get; set; }

        [JsonPropertyName("fechaSolicitud")]
        public DateTime FechaSolicitud { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nombreUsuarioSolicitante")]
        public string NombreUsuarioSolicitante { get; set; } = string.Empty;

        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }

        [JsonPropertyName("isbNs")]
        public List<string> ISBNs { get; set; } = new();

        [JsonPropertyName("titulosLibros")]
        public List<string> TitulosLibros { get; set; } = new();

        [JsonIgnore]
        public string ISBNsMostrados => ISBNs != null ? string.Join(", ", ISBNs) : string.Empty;

        [JsonIgnore]
        public string LibrosSolicitados => TitulosLibros != null ? string.Join(" | ", TitulosLibros) : string.Empty;
    }
}
