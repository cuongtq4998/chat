using System;
using System.Net.Http;

namespace ChatBot.Services
{
    public interface IHttpService
    { 
        Uri BaseAddress { get; set; }
        HttpClient HttpClient { get; }
    }
}
