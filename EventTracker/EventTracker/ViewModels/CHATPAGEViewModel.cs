using ChatBot.Items;
using ChatBot.Services.ChatService;
using ChatBot.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    public class CHATPAGEViewModel : BaseViewModel
    {
        ChatRepository _chatService;

        public CHATPAGEViewModel()
        {
            _chatService = new ChatRepository();
        }

        private string _mesage;
        public string Mesage
        {
            get => _mesage;
            set => SetProperty(ref _mesage, value);
        }

        private ObservableCollection<ItemChatViewModel> _listData = new ObservableCollection<ItemChatViewModel>();
        public ObservableCollection<ItemChatViewModel> ListData
        {
            get => _listData;
            set => SetProperty(ref _listData, value);
        }

        public ICommand SendCommand
        {
            get => new Command<object>(
                (object obj) =>
                {
                    AddMesage(Mesage, true);
                    SendChat(Mesage);
                    Mesage = string.Empty;
                });
        }

        private void AddMesage(string mesage,bool myText )
        {
            ItemChatViewModel item = new ItemChatViewModel();
            item.TextChat = mesage;
            item.MyChat = myText;

            Device.BeginInvokeOnMainThread(() => {
                ListData.Add(item);
            });
        }

        public void SendChat(string m)
        {
            try
            {
                _chatService.SendChat(new Services.Models.SendChatRequestDto
                {
                    context = new string[] { "shop" },
                    lang = "en",
                    query = m,
                    sessionId = "12345",
                    timwezone = "America/New_York"
                }).Subscribe(_ =>
                {
                    AddMesage(_.result.fulfillment.messages[0].speech, false);
                }, ex =>
                {
                    Debug.WriteLine(ex);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
       
    }
}
