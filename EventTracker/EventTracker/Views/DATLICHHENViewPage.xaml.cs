using ChatBot.Models;
using ChatBot.Services;
using ChatBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DATLICHHENViewPage : ContentPage
    { 
       
        public DATLICHHENViewPage(THONGTINDICHVU thongtindichvu)
        {
            InitializeComponent();
            var vm = this.BindingContext as DatLichHenViewModell;
            if (vm != null)
            {
                vm.datLichhen.IDDV = thongtindichvu.ID;
                vm.thongtindichvu.Add(thongtindichvu);
            }
            //BindingContext = new MainPageViewModel(); 
        }
       

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (datlichhen != null)
            //{
            //    datlichhen.IsSelected = false;
            //}
            //SetIsSelected currentModel = e.SelectedItem as SetIsSelected;
            //currentModel.IsSelected = true;
            //datlichhen = currentModel;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var vm = this.BindingContext as DatLichHenViewModell;
            if (vm != null)
            { 
                if (vm.checknavigate == true)
                {
                    Navigation.PopToRootAsync();
                }
            } 
           
           
        } 
         
    }
}