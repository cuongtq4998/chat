using ChatBot.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventTracker
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Expander_Experimental" });
            //Device.SetFlags(new string[] { "Shapes_Experimental" });
            InitializeComponent(); 
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 
    }
}
