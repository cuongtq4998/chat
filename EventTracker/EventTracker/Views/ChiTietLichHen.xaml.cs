using ChatBot.Models;
using ChatBot.RestClient;
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
    public partial class ChiTietLichHen : ContentPage
    {
        private DatLichHen datLichHen;
        private THONGTINDICHVU thongtindichvu;
        public ChiTietLichHen(getDatHenThongTinDichVu getdatlichhen)
        {  
            InitializeComponent();
            datLichHen = new DatLichHen
            {
                YeuCau = getdatlichhen.DatLichHen.YeuCau,
                ID = getdatlichhen.DatLichHen.ID,
                ThoiGianHen = getdatlichhen.DatLichHen.ThoiGianHen,
                TrangThaiLichHen = getdatlichhen.DatLichHen.TrangThaiLichHen,
                NgayTao = getdatlichhen.DatLichHen.NgayTao,
                NoiDungHuy = getdatlichhen.DatLichHen.NoiDungHuy,
                ThoiGianNhacNho = getdatlichhen.DatLichHen.ThoiGianNhacNho
            };
            
            thongtindichvu = new THONGTINDICHVU
            {
                ID = getdatlichhen.ThongTinDichVu.ID,
                TieuDeDV = getdatlichhen.ThongTinDichVu.TieuDeDV,
                NoiDungDV = getdatlichhen.ThongTinDichVu.NoiDungDV,
                ImageDV = getdatlichhen.ThongTinDichVu.ImageDV,
                ChiPhiDV = getdatlichhen.ThongTinDichVu.ChiPhiDV
            };

            YeuCau.BindingContext = datLichHen ;
            ThoiGianHen.BindingContext = datLichHen ;
            //ThoiGianNhacNho.BindingContext = datLichHen ;
            //NoiDungHuy.BindingContext = datLichHen ;
            //TrangThaiLichHen.BindingContext = datLichHen ;

            //TieuDeDV.BindingContext = thongtindichvu;
            NoiDungDV.BindingContext = thongtindichvu;
            ImageDV.BindingContext = thongtindichvu;
            ChiPhiDV.BindingContext = thongtindichvu;

           
            if(datLichHen.ThoiGianHen < DateTime.Now)
            {
                HuyLichHen.IsVisible = false;
            }
            else if (datLichHen.TrangThaiLichHen == 0)
            {
                NoteCancel.Text = "Lịch hẹn của bạn đã được hủy!";
                HuyLichHen.IsVisible = false;
            }
            else
            {
                HuyLichHen.IsVisible = true;
            }
        }

        private void HuyLichHen_Clicked(object sender, EventArgs e)
        {
            showPopupAsync();
        }
        public async Task showPopupAsync()
        {
            string action = await DisplayActionSheet("Lý Do Của Bạn?", "Không", null, "Bận Công Việc", "Đặt Lại Lịch", "Lí do khác.");


            Console.WriteLine("Action: " + action);

            if(action != null)
            {
                bool answer = await DisplayAlert("Thông báo?", "Bạn có chắc muốn hủy?", "Đồng ý", "Không");
                if (answer)
                {
                    var services = new Service();
                    datLichHen.NoiDungHuy = action;
                    datLichHen.TrangThaiLichHen = 0;
                    _ = services.PutHuyLichHen(datLichHen, (int)getLinkPage.linkDatLichHen);
                    _ = Navigation.PopToRootAsync();
                } 
            }
            
        }
    }
}