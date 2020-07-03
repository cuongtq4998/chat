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
    class ChatKNNViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private ObservableCollection<CHAMSOCKH> _items;
        //public ObservableCollection<CHAMSOCKH> listItem
        //{
        //    get { return _items; }
        //    set
        //    {
        //        _items = value;
        //        OnPropertyChanged();
        //    }
        //}
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ChatKNNViewModel()
        {

        }
        private string _messageInput; 
        public string messageInput
        {
            get { return _messageInput; }
            set
            {
                _messageInput = value;
            }
        }
        //public Command buttonSend
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            var services = new Service();
        //            await services.PostCustomers(_messageInput, (int)getLinkPage.linkKhachHang);

        //        });
        //    }
        //}
    }
}
