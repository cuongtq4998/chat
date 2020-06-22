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
    // class MainPageViewModel: INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    private ObservableCollection<THONGTINDICHVU> _dichVuList;
    //    public ObservableCollection<THONGTINDICHVU> dichVuList
    //    {
    //        get { return _dichVuList; }
    //        set
    //        {
    //            _dichVuList = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //    private List<SetIsSelected> _Items;
    //    public List<SetIsSelected> Items
    //    {
    //        get { return _Items; }
    //        set
    //        {
    //            _Items = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    //public ObservableCollection<SetIsSelected> Items { set; get; }
    //    public MainPageViewModel()
    //    {
    //         InitializeDataAsync(); 
    //    }  

    //    private async Task InitializeDataAsync()
    //    {
    //        var services = new Service();
    //        dichVuList = await services.GetTTDV(2);
    //        List<SetIsSelected> list = new List<SetIsSelected>();
    //        list.Add(new SetIsSelected { IsSelected = false, TieuDeDV = dichVuList[0].TieuDeDV });
    //        Items = list;
    //    }
    //}

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
            //if (currentModel.IsSelected)
            //{
            //    var viewModel = BindingContext as MainPageViewModel;
            //    int index = viewModel.Items.IndexOf(currentModel);
            //}
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