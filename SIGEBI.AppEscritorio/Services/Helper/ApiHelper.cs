using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Helper
{
    public class ApiHelper
    {
        public static async Task ProcesarErrorApiAsync(HttpResponseMessage respuesta)
        {
            // Si la respuesta fue exitosa (200-299), salimos del método sin hacer nada.
            if (respuesta.IsSuccessStatusCode) return;

            var error = await respuesta.Content.ReadAsStringAsync();

            try
            {
                var json = JsonDocument.Parse(error);
                // Buscamos la propiedad "mensaje" que envía tu backend en los BadRequest/NotFound
                if (json.RootElement.TryGetProperty("mensaje", out var mensajeProp))
                {
                    throw new Exception(mensajeProp.GetString());
                }
                throw new Exception("Error al procesar la solicitud en el servidor.");
            }
            catch (JsonException)
            {
                // Si la API se cae o devuelve un HTML de error (como un 500 del servidor)
                throw new Exception(string.IsNullOrEmpty(error) ? "Error de conexión con la API." : error);
            }
        }
    }
}
