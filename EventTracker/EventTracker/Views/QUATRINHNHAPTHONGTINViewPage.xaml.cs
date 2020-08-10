using ChatBot.ABC;
using ChatBot.Models;
using ChatBot.ViewModels;
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
    public partial class QUATRINHNHAPTHONGTINViewPage : ContentPage
    {
        public QUATRINHNHAPTHONGTINViewPage(List<User_KH> data)
        { 
            InitializeComponent();
            var vm = this.BindingContext as QUATRINHNHAPTHONGTINViewModel;
            if(vm != null)
            {
                vm.SelectedCustomers.user_KH = data;
            }
        }

        private void ButtonWithPadding_Clicked(object sender, EventArgs e)
        {
            var vm = this.BindingContext as QUATRINHNHAPTHONGTINViewModel;
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