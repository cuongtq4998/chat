
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Services
{
    public class DefaultHttpClientHandler : HttpClientHandler
    {
        private readonly INetworkInfoService _networkInfoService;

        public DefaultHttpClientHandler(INetworkInfoService networkInfoService)
        {
            _networkInfoService = networkInfoService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryAddWithoutValidation("Authorization", "Bearer fcf0976f4fcf498fb131bc63dcb824cc");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}