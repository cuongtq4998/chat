using ChatBot.Models;
using MvvmHelpers;
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
    public partial class THONGBAOViewPage : ContentPage
    {
        public THONGBAOViewPage()
        {
            InitializeComponent(); 
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelectedData = e.Item as ObservableObject;
            if (itemSelectedData is CHAMSOCKH)
            {
                //DisplayAlert("Alert", "Chăm sóc khách hàng", "OK");
                var itemThongBao = itemSelectedData as CHAMSOCKH;
                Navigation.PushAsync(new ChiTietThongBaoViewPage(itemThongBao));
            }
            else
            {
                var itemDatLichHen = itemSelectedData as ViewModels.ketnoiDLH_TTDV;
                Navigation.PushAsync(new RatingViewPage(itemDatLichHen));

            }
        }
        bool isLoaded = false;
        protected override void OnAppearing()
        { 
            if (!isLoaded)
            {
                //Do API Calls
                var vm = new ViewModels.THONGBAOViewModel();

                vm.InitializeDataAsync();
                isLoaded = true;
            }
           
        }
    }
}