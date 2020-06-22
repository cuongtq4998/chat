using ChatBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CHATViewPage : ContentPage
    {
        CHATPAGEViewModel viewmodel;

        public CHATViewPage()
        {
            viewmodel = new CHATPAGEViewModel();
            this.BindingContext = viewmodel;
            InitializeComponent();
        }
    }
}