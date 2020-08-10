using ChatBot.ABC;
using ChatBot.Models;
using ChatBot.Services;
using ChatBot.ViewModels;
using EventTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LOGIN : ContentPage
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void ChuyenPageNhapThongTin_Clicked(object sender, EventArgs e)
        {
            var vm = this.BindingContext as LOGINViewModel;
            if (vm != null)
            {
                if (vm.checknavigate == true)
                {
                    Navigation.PushAsync(new TRANGCHUDEMO());
                }
            }
        } 
    }
}