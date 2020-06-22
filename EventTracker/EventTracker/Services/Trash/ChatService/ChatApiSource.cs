using System;
using ChatBot.Services.Models;
using Refit;

namespace ChatBot.Services.ChatService
{
    public class ChatApiSource
    {
        public string EndPoint => "https://api.dialogflow.com/v1";

        IRestService _restService;
        IHttpService httpService;

        public ChatApiSource()
        {
            httpService = new HttpService();
            httpService.BaseAddress = new Uri(EndPoint);
            _restService = RestService.For<IRestService>(httpService.HttpClient);
        }

        public IObservable<SendChatReponseDto> SendChat(SendChatRequestDto input)
        {
            return _restService.SendChat(input);
        }
    }
}
