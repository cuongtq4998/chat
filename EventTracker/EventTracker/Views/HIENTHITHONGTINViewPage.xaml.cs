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
	public partial class HIENTHITHONGTINViewPage : ContentPage
	{
		public HIENTHITHONGTINViewPage ()
		{
			InitializeComponent ();
            var vm = new HIENTHITHONGTINViewModel();
            vm.getDataAsync();
        }
        private void Btn_chat_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CHATViewPage());
        }
    }
}