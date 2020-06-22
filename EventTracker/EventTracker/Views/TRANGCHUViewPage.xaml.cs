using ChatBot.Models;
using ChatBot.Services;
using EventTracker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TRANGCHUviewPage : TabbedPage
	{
		public TRANGCHUviewPage ()
		{
			InitializeComponent ();

		}

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            int indexPage = Children.IndexOf(CurrentPage);

            if (indexPage == 1)
            {
                //loadDVAsync();
                //DisplayAlert("Alert", "You have been alerted 1", "OK");
            }
            else if (indexPage == 2)
            {
                //DisplayAlert("Alert", "You have been alerted 2", "OK");
            }
            else
            {
                //DisplayAlert("Alert", "You have been alerted 3", "OK");
            }
        }
        //private ObservableCollection<THONGTINDICHVU> _dichVuList;
        //public ObservableCollection<THONGTINDICHVU> dichVuList
        //{
        //    get
        //    {
        //        return _dichVuList;
        //    }
        //    set
        //    {
        //        _dichVuList = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public async Task loadDVAsync()
        //{

        //    var customersService = new Service();

        //    dichVuList = await customersService.GetTTDV(2);
        //}
    }
	
}