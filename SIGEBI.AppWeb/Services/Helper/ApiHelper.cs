using System.Text.Json;

namespace SIGEBI.AppWeb.Services
{
    public static class ApiHelper
    {
        public static async Task ProcesarErrorApiAsync(HttpResponseMessage respuesta)
        {
            var error = await respuesta.Content.ReadAsStringAsync();

            try
            {
                var json = JsonDocument.Parse(error);
                if (json.RootElement.TryGetProperty("mensaje", out var mensajeProp))
                {
                    throw new Exception(mensajeProp.GetString());
                }
                throw new Exception("Error al procesar la solicitud.");
            }
            catch (JsonException) 
            {
                throw new Exception(string.IsNullOrEmpty(error) ? "Error al procesar en la API." : error);
            }
        }
    }
}