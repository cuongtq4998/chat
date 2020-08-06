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
            //Navigation.PushAsync(new HIENTHITHONGTINViewPage());
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
            if(vm.confilmPassword != vm.userKhachHang.matKhau)
            {
                DisplayAlert("Thông báo", "Xác nhận mật khẩu không hợp lệ!", "OK"); 
            }
            else if ( vm.confilmPassword == null ||
                vm.userKhachHang.taiKhoan == null ||
                vm.userKhachHang.matKhau == null)
            {
                DisplayAlert("Thông báo", "Bạn hãy điền thông tin đầy đủ!", "OK");
            }
            else
            {
                Navigation.PushAsync(new QUATRINHNHAPTHONGTINViewPage(KH));
            }
            
        }
    }
}