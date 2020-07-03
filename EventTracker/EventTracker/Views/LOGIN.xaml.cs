using ChatBot.Models;
using ChatBot.Services;
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
    public partial class LOGIN : ContentPage
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void ChuyenPageNhapThongTin_Clicked(object sender, EventArgs e)
        { 
            var vmLogin = this.BindingContext as LOGINViewModel;
            var vmTT = BindingContext as HIENTHITHONGTINViewModel;
            if(vmLogin.khachhangList != null)
            {
                Navigation.PushAsync(new HIENTHITHONGTINViewPage(vmLogin.khachhangList));
            }
            
           
        } 
    }
}