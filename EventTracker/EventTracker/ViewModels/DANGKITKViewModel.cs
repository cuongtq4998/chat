using ChatBot.Models;
using ChatBot.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    class DANGKITKViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private User_KH _userKH = new User_KH();
        public User_KH userKhachHang
        {
            get { return _userKH; }
            set
            {
                userKhachHang = value;
                OnPropertyChanged();
            }
        }    
    }
}
