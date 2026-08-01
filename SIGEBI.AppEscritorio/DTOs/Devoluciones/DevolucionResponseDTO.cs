using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Devoluciones
{
    public class DevolucionResponseDTO
    {
        [JsonPropertyName("idDevolucion")]
        public int IdDevolucion { get; set; }

        [JsonPropertyName("fechaDevolucion")]
        public DateTime FechaDevolucion { get; set; }

        [JsonPropertyName("condicionLibro")]
        public string CondicionLibro { get; set; } = string.Empty;

        [JsonPropertyName("observaciones")]
        public string Observaciones { get; set; } = string.Empty;

        [JsonPropertyName("idPrestamo")]
        public int IdPrestamo { get; set; }

        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [JsonPropertyName("idBibliotecario")]
        public int IdBibliotecario { get; set; }

        [JsonPropertyName("generoPenalizacion")]
        public bool GeneroPenalizacion { get; set; }

        [JsonPropertyName("diasRetraso")]
        public int DiasRetraso { get; set; }

        [JsonPropertyName("titulosLibros")]
        public List<string> TitulosLibros { get; set; } = new();
    }
}