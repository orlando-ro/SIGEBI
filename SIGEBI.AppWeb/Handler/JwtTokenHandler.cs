using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace SIGEBI.AppWeb.Handlers
{
    public class JwtTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 1. Buscamos el token en la sesión del usuario actual
            var token = _httpContextAccessor.HttpContext?.Session.GetString("TokenJwt");

            // 2. Si existe, lo inyectamos automáticamente en la cabecera de la petición saliente
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // 3. Dejamos que la petición continúe su viaje hacia la API
            return await base.SendAsync(request, cancellationToken);
        }
    }
}