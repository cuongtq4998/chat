using System;
using System.Reactive.Linq;
using ChatBot.Services.Models;

namespace ChatBot.Services.ChatService
{
    public class ChatRepository
    {
        private ChatApiSource _remoteSource;

        public ChatRepository()
        {
            _remoteSource = new ChatApiSource();
        }

        public IObservable<SendChatReponseDto> SendChat(SendChatRequestDto input)
        {
            return Observable.Defer(() =>
            {
                return _remoteSource.SendChat(input).Select(_ =>
                {
                    return _;
                });
            });
        }

    }
}
