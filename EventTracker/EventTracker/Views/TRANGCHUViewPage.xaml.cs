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
    public partial class TRANGCHUViewPage : ContentPage
    {
        public TRANGCHUViewPage()
        {
            InitializeComponent();
        }
        public async void CameraButtonTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new CameraPage());
        }

        public async void TagButtonTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new TagPage());
        }

        public async void ShoppingButtonTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new ShoppingPage());
        }

        public async void TwitterButtonTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new TwitterPage());
        }
    }
}