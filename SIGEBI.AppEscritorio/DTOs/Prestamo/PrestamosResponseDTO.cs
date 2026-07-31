using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Prestamos
{
    public class PrestamoResponseDTO
    {
        [JsonPropertyName("idPrestamo")]
        public int IdPrestamo { get; set; }

        [JsonPropertyName("fechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("fechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [JsonPropertyName("diasRetraso")]
        public int DiasRetraso { get; set; }

        [JsonPropertyName("estaVencido")]
        public bool EstaVencido { get; set; }

        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }

        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [JsonPropertyName("isbNs")]
        public List<string> ISBNs { get; set; } = new();

        [JsonPropertyName("titulosLibros")]
        public List<string> TitulosLibros { get; set; } = new();
    }
}