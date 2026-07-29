using System.Net.Http.Json;
using SIGEBI.AppWeb.Models.Solicitudes;



namespace SIGEBI.AppWeb.Services
{
    public class ServicioSolicitudApi
    {
        private readonly HttpClient _httpclient; // se usa para realizar solicitudes HTTP a la API
        

        public ServicioSolicitudApi(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpclient = httpClient;
            
            var baseUrl = configuration["ApiSettings:BaseUrl"] ?? "http://localhost:7291/api";
            _httpclient.BaseAddress = new Uri(baseUrl);
        }


        public async Task<SolicitudItemViewModel> CrearSolicitudAsync(List<string> isbnLibros) { 
        
            var playload = new { ISBNs = isbnLibros }; 



        }
    }
}
