using System;
using ChatBot.Services.Models;
using Refit;

namespace ChatBot.Services.ChatService
{
    public interface IRestService
    {
        [Post("/query?v=20150910")]
        IObservable<SendChatReponseDto> SendChat([Body] SendChatRequestDto input);

    }
}
