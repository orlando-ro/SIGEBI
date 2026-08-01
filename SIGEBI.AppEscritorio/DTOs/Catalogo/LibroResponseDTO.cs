using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Catalogo
{
    public class LibroResponseDTO
    {
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; } = string.Empty;

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("nombreAutor")]
        public string NombreAutor { get; set; } = string.Empty;

        [JsonPropertyName("anioPublicacion")]
        public int AnioPublicacion { get; set; }

        [JsonPropertyName("copiasDisponibles")]
        public int CopiasDisponibles { get; set; }

        [JsonPropertyName("categoria")]
        public string Categoria { get; set; } = string.Empty;

        [JsonPropertyName("urlImagen")]
        public string? UrlImagen { get; set; }
    }

    public class LibroUpdateDTO
    {
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("nombreAutor")]
        public string NombreAutor { get; set; } = string.Empty;

        [JsonPropertyName("anioPublicacion")]
        public int AnioPublicacion { get; set; }

        [JsonPropertyName("idCategoria")]
        public int IdCategoria { get; set; }
    }
}