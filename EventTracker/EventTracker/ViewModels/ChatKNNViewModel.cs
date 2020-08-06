using ChatBot.RestClient;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    public class ItemChatViewModel
    {
        public string TextChat { get; set; }
        public bool MyChat { get; set; }
    }
    class ChatKNNViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       


        private ObservableCollection<ItemChatViewModel> _listData = new ObservableCollection<ItemChatViewModel>();
        public ObservableCollection<ItemChatViewModel> ListData
        {
            get { return _listData; }
            set
            {
                _listData = value;
            }
        }
        private string _messageInput = "";
        public string messageInput
        {
            get { return _messageInput; }
            set
            {
                _messageInput = value;
                OnPropertyChanged();
            }
        }

        public Command buttonSend
        {
            get
            {
                return new Command(async () =>
                {
                    AddMesage(messageInput, true);
                    var services = new Service();
                    List<string> myMessage = await services.getMessage(messageInput);
                    messageInput = string.Empty;
                    AddMesage(myMessage[0], false); 
                });
            }
        }

        private void AddMesage(string mesage, bool myText)
        {
            ItemChatViewModel item = new ItemChatViewModel();
            item.TextChat = mesage;
            item.MyChat = myText;

            Device.BeginInvokeOnMainThread(() => {
                ListData.Add(item);
            });
        }

        public ChatKNNViewModel()
        {
            if (ListData.Count <= 0)
            {
                AddMesage("Chúng tôi có thể giúp gì cho bạn?", false);
            }

        }
    }
}
