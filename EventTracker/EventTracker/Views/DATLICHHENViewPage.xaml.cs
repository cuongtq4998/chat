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
        SetIsSelected datlichhen;
        public DATLICHHENViewPage()
        {
            InitializeComponent();
           
            //BindingContext = new MainPageViewModel(); 
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
                var viewModel = BindingContext as DatLichHenViewModell;
                int index = viewModel.Items.IndexOf(currentModel);
                viewModel.getTTDV = index;
            }
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
    }
}