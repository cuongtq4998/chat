using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private string _newProperty = "aasdsa";
        public string NewProperty
        {
            get => _newProperty;
            set => SetProperty(ref _newProperty, value);
        }

        public ICommand Command
        {
            get => new Command<object>(
                (object obj) =>
                {

                });
        }
    }
}
