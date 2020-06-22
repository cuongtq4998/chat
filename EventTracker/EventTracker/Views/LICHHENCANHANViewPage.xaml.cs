﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LICHHENCANHANViewPage : ContentPage
    {
        public LICHHENCANHANViewPage()
        {
            InitializeComponent();
        }

        private void NavigationThemLichHen_Clicked(object sender, EventArgs e)
        {
             NavigationThemLichHenAsync();
        }

        private async Task NavigationThemLichHenAsync()
        {
            await Navigation.PushAsync(new DATLICHHENViewPage()); 
        }
    }
}