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
	public partial class DANGKITKViewPage : ContentPage
	{
		public DANGKITKViewPage ()
		{
			InitializeComponent ();
		}
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HIENTHITHONGTINViewPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CHATViewPage());
        }

        private void ChuyenPageNhapThongTin_Clicked(object sender, EventArgs e)
        {
            var vm = this.BindingContext as DANGKITKViewModel;
            List<User_KH> KH = new List<User_KH>();
            KH.Add(vm.userKhachHang);

            Navigation.PushAsync(new QUATRINHNHAPTHONGTINViewPage(KH));
        }
    }
}