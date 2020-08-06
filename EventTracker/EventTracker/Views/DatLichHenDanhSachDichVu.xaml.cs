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
    public partial class DatLichHenDanhSachDichVu : ContentPage
    {
        THONGTINDICHVU thongtindichvu = new THONGTINDICHVU();
        SetIsSelected datlichhen;
        public DatLichHenDanhSachDichVu()
        {
            InitializeComponent();
        }
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (datlichhen != null)
            {
                datlichhen.IsSelected = false;
            }
            SetIsSelected currentModel = ((CheckBox)sender).BindingContext as SetIsSelected;
            datlichhen = currentModel;

            //get index check
            if (currentModel.IsSelected)
            {
                TiepTucNhapThongTin.IsEnabled = true;
                var viewModel = BindingContext as DatLichHenDanhSachDichVuViewModel;
                int index = viewModel.Items.IndexOf(currentModel);
                thongtindichvu = viewModel.listTTDV[index].THONGTINDICHVU;
                //viewModel.datLichhen.IDDV = viewModel.listTTDV[index].THONGTINDICHVU.ID;
            }
            else
            {
                TiepTucNhapThongTin.IsEnabled = false;
            }
        }

        private void TiepTucNhapThongTin_Clicked(object sender, EventArgs e)
        { 
            Navigation.PushAsync(new DATLICHHENViewPage(thongtindichvu));
        }
    }
}