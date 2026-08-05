using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Solicitudes
{
    public class SolicitudResponseDTO
    {
        [Browsable(false)] // Oculto en la tabla
        [JsonPropertyName("idSolicitud")]
        public int IdSolicitud { get; set; }

        [DisplayName("Fecha de Solicitud")]
        [JsonPropertyName("fechaSolicitud")]
        public DateTime FechaSolicitud { get; set; }

        [DisplayName("Estado Actual")]
        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [Browsable(false)]
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [Browsable(false)]
        [JsonPropertyName("nombreUsuarioSolicitante")]
        public string NombreUsuarioSolicitante { get; set; } = string.Empty;

        [Browsable(false)]
        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [Browsable(false)]
        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }

        [Browsable(false)]
        [JsonPropertyName("isbNs")]
        public List<string> ISBNs { get; set; } = new();

        [Browsable(false)]
        [JsonPropertyName("titulosLibros")]
        public List<string> TitulosLibros { get; set; } = new();

        [Browsable(false)]
        [JsonIgnore]
        public string ISBNsMostrados => ISBNs != null ? string.Join(", ", ISBNs) : string.Empty;

        [Browsable(false)]
        [JsonIgnore]
        public string LibrosSolicitados => TitulosLibros != null ? string.Join(" | ", TitulosLibros) : string.Empty;
    }
}