using ChatBot.ViewModels;
using System;
using System.Collections.Generic;
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
        
        public RatingViewPage()
        { 
            InitializeComponent();
            this.BindingContext = new RattingBarViewModal();
            Title = "Đánh giá chúng tôi!"; 

        } 
    }
}