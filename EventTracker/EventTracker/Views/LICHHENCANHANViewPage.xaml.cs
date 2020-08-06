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
    public partial class LICHHENCANHANViewPage : ContentPage
    {
        public LICHHENCANHANViewPage()
        {
            InitializeComponent();
        }

        private void NavigationThemLichHen_Clicked(object sender, EventArgs e)
        {
            _ = NavigationThemLichHenAsync();
        }

        private async Task NavigationThemLichHenAsync()
        {
            //await Navigation.PushAsync(new DATLICHHENViewPage()); 
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelectedData = e.Item as getDatHenThongTinDichVu; 
            Navigation.PushAsync(new ChiTietLichHen(itemSelectedData));


            //var itemSelectedData = e.Item as ObservableObject;
            //if (itemSelectedData is CHAMSOCKH)
            //{
            //    DisplayAlert("Alert", "Chăm sóc khách hàng", "OK");
            //}
            //else
            //{
            //    var itemDatLichHen = itemSelectedData as ViewModels.ketnoiDLH_TTDV;
            //    Navigation.PushAsync(new RatingViewPage(itemDatLichHen));

            //}
        }
    }
}