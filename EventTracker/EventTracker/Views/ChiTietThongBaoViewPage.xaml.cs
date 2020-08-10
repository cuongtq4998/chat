using ChatBot.Models;
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
    public partial class ChiTietThongBaoViewPage : ContentPage
    {
        private CHAMSOCKH CSKH;
        public ChiTietThongBaoViewPage(CHAMSOCKH chamSocKH)
        {
            InitializeComponent();
            CSKH = chamSocKH;

            tieU_DE.BindingContext = CSKH;
            ImageDVV.BindingContext = CSKH;
            noI_DUNG.BindingContext = CSKH;
            TieuDeDV.BindingContext = CSKH;
            ChiPhiDV.BindingContext = CSKH;
            NoiDungDV.BindingContext = CSKH;
         }

        private void DatHenNgay_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DatLichHenDanhSachDichVu());
        }
    }
}