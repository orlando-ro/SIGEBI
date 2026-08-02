using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace SIGEBI.AppEscritorio.Services.Helper
{
    public static class ApiHelper
    {
        public static async Task ProcesarErrorApiAsync(this HttpResponseMessage respuesta)
        {
            if (respuesta.IsSuccessStatusCode) return;

            var error = await respuesta.Content.ReadAsStringAsync();

            try
            {
                var json = JsonDocument.Parse(error);

                if (json.RootElement.TryGetProperty("mensaje", out var mensajeProp))
                {
                    var extraido = mensajeProp.GetString();
                    if (!string.IsNullOrWhiteSpace(extraido))
                    {
                        throw new Exception(extraido);
                    }
                }
                throw new Exception("Error al procesar la solicitud en el servidor.");
            }
            catch (JsonException)
            {
                string mensajeSeguro = (!string.IsNullOrWhiteSpace(error) && error.Length < 200)
                    ? error
                    : "Error crítico de conexión o respuesta inválida del servidor.";

                throw new Exception(mensajeSeguro);
            }
        }
    }
}