using SIGEBI.AppEscritorio.Utils;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Handlers
{
    public class AuthHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Si el usuario ya inició sesión, adjuntamos el Token a la cabecera de la petición
            if (SessionManager.IsLoggedIn)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.Token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}