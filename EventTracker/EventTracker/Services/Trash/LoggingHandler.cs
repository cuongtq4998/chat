﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Services
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Request:");
            Debug.WriteLine(request.ToString());
            if (request.Content != null)
            {
                var a = await request.Content.ReadAsStringAsync();
                Debug.WriteLine(a);
            }
            Debug.WriteLine(string.Empty);

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine("Response:");
            Debug.WriteLine(response.ToString());
            if (response.Content != null)
            {
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
            }
            Debug.WriteLine(string.Empty);

            return response;
        }
    }
}
