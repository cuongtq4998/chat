using System;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace ChatBot.Services
{
    public class HttpService : IHttpService
    {
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _cookieContainer = new CookieContainer();

            INetworkInfoService networkInfoService = DependencyService.Get<INetworkInfoService>();
            var clientHandler = new DefaultHttpClientHandler(networkInfoService)
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = _cookieContainer,
                UseProxy = true,
            };


            if (clientHandler.SupportsAutomaticDecompression)
                clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


#if DEBUG
            _httpClient = new HttpClient(new LoggingHandler(clientHandler));
#else
            _httpClient = new HttpClient(clientHandler);
#endif

        }

        public Uri BaseAddress
        {
            get => _httpClient.BaseAddress;
            set => _httpClient.BaseAddress = value;
        }

        public HttpClient HttpClient
        {
            get => _httpClient;
        }
    }
}
