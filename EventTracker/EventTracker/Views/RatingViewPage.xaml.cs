using ChatBot.ABC;
using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using ChatBot.ViewModels;
using Plugin.InputKit.Shared;
using Plugin.InputKit.Shared.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingViewPage : ContentPage
    {
        public IList<NoiDungDanhGiaClass> getMyList { get; set; } = new ObservableCollection<NoiDungDanhGiaClass>();
        public string danhGia { get; set; } 
        public RatingViewPage(ketnoiDLH_TTDV datlichhen)
        {
            InitializeComponent();
            var vm = this.BindingContext as RattingBarViewModal;
            if (vm != null)
            {
                vm.SelectedCustomers.id = datlichhen.IdDanhGia;
                vm.SelectedCustomers.idDatLichHen = datlichhen.datLichHen.ID;
                getMyList = vm.MyList;  
            }
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectionView.SelectionType = (SelectionType)picker.SelectedItem;
            
        }

        private void LabelPositionChanged(object sender, EventArgs e)
        {
            //if (sender is Picker pkr)
            //{
            //    selectionView.LabelPosition = (LabelPosition)pkr.SelectedItem;
            //}
        }
         
        private void GuiDanhGiaButton_Clicked(object sender, EventArgs e)
        {
            if (selectionView.SelectedIndexes.ToArray().Count() <= 0)
            {
                DisplayAlert("Alert", "Vui Lòng Chọn Đánh Giá ", "OK");
            }
            else
            {
                int[] giatri = selectionView.SelectedIndexes.ToArray();

                for (int i = 0; i < giatri.Count(); i++)
                {
                    for (int itemData = 0; itemData <= getMyList.Count; itemData++)
                    {
                        if (giatri[i] == itemData)
                        {
                            danhGia += getMyList[itemData].Name.ToString() + " , ";
                        }
                    }
                }
                var vm = this.BindingContext as RattingBarViewModal;
                vm.SelectedCustomers.noiDungDanhGia = danhGia;
                var services = new Service();
                _ = services.PostDanhGia(vm.SelectedCustomers, (int)getLinkPage.linkGetChamSocKH);
                Navigation.PopToRootAsync();
            }  
        } 
    }
}