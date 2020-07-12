using ChatBot.Controls;
using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using EventTracker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    class RattingBarViewModal : INotifyPropertyChanged
    {
        private ketnoiDLH_TTDV _datlichhen;
        public ketnoiDLH_TTDV datlichhen
        {
            get { return _datlichhen; }
            set { _datlichhen = value;
                NotifyPropertyChanged(); 
            }
        }
        public ICommand rattingBarCommand { get; set; }
        public ICommand clickCommand { get; set; }
        public RattingBarViewModal()
        {
            rattingBarCommand = new Command(onItemTapped); // this will execute on tap of image (star)
            clickCommand = new Command(onClicked); // this will execute on the click of Click me button.  
            FillData();  
        }

        void onClicked(object obj)
        {
            RattingBarRating b = (RattingBarRating)obj; 
            App.Current.MainPage.DisplayAlert("Selected Value is", b.SelectedStarValue.ToString(), "OK");
        }
         
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _selectedStar;
        public string SelectedStar
        {
            get { return _selectedStar; }
            set { _selectedStar = value; NotifyPropertyChanged(); }
        }

       

        private void onItemTapped(object obj)
        {
            var obje = obj;
            int number = (int)obj;
            if(number <= 3)
            {
                SelectedStar = "Bạn muốn cải thiện điều gì ở chúng tôi?";
            }
            if (number == 4)
            {
                SelectedStar = "Bạn cảm thấy còn chưa tốt điều gì?";
            }
            if (number == 5)
            {
                SelectedStar = "Tuyệt vời!";
            }

            SelectedCustomers.mucDoHaiLong = number;
            //SelectedStar = "Selected Star is " + obj;
        }


        //  

        private DanhGia _SelectedCustomers = new DanhGia(); 
        public DanhGia SelectedCustomers
        {
            get { return _SelectedCustomers; }
            set
            {
                _SelectedCustomers = value; 
            }
        } 

        //chọn đánh giá 
        public IList<NoiDungDanhGiaClass> MyList { get; set; } = new ObservableCollection<NoiDungDanhGiaClass>();
        private NoiDungDanhGiaClass _selectedItem;
        private int _selectedIndex;

        public NoiDungDanhGiaClass SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; NotifyPropertyChanged(); }
        }

        void FillData()
        {
            MyList.Add(new NoiDungDanhGiaClass { Id = 0, Name = "Không gian phục vụ " });
            MyList.Add(new NoiDungDanhGiaClass { Id = 1, Name = "Chất lượng dịch vụ " });
            MyList.Add(new NoiDungDanhGiaClass { Id = 2, Name = "Thái độ nhân viên "  });
        }
    }
}

