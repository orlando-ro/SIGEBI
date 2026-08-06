using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Devoluciones
{
    public class DevolucionResponseDTO
    {
        [Browsable(false)]
        [JsonPropertyName("idDevolucion")]
        public int IdDevolucion { get; set; }

        [DisplayName("Fecha Devolución")]
        [JsonPropertyName("fechaDevolucion")]
        public DateTime FechaDevolucion { get; set; }

        [DisplayName("Usuario")]
        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [DisplayName("Condición de Entrega")]
        [JsonPropertyName("condicionLibro")]
        public string CondicionLibro { get; set; } = string.Empty;

        
        [Browsable(false)]
        [JsonPropertyName("observaciones")]
        public string Observaciones { get; set; } = string.Empty;

        [DisplayName("Días Retraso")]
        [JsonPropertyName("diasRetraso")]
        public int DiasRetraso { get; set; }

        [Browsable(false)]
        [JsonPropertyName("generoPenalizacion")]
        public bool GeneroPenalizacion { get; set; }

        [Browsable(false)]
        [JsonPropertyName("titulosLibros")]
        public List<string> TitulosLibros { get; set; } = new();
    }
}