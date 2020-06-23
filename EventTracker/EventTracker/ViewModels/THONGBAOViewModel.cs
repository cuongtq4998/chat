using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    class THONGBAOViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<CHAMSOCKH> _items;
        public ObservableCollection<CHAMSOCKH> listItem
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public THONGBAOViewModel()
        {
            #region DumaData
            Random random = new Random();
            //listItem = new List<Customers>
            //{
            //    new Customers
            //    {
            //        ID = Path.GetRandomFileName(),
            //        HoTen = "Trần Quốc " + random.Next( 1,30),
            //        DiaChi = "Thành Phố Hồ Chí Minh",
            //        DienThoai = "",
            //        GioiTinh = "Nam",
            //        Email = "",
            //        NgaySinh = DateTime.Now
            //    },
            //    new Customers
            //    {
            //        ID = Path.GetRandomFileName(),
            //        HoTen = "Trần Quốc " + random.Next( 1,30),
            //        DiaChi = "Lê Trọng Tấn,  Sơn Kì, Tần Phú",
            //        DienThoai = "",
            //        GioiTinh = "Nam",
            //        Email = "",
            //        NgaySinh = DateTime.Now
            //    },
            //    new Customers
            //    {
            //        ID = Path.GetRandomFileName(),
            //        HoTen = "Trần Quốc " + random.Next( 1,30),
            //        DiaChi = "",
            //        DienThoai = "",
            //        GioiTinh = "Nam",
            //        Email = "",
            //        NgaySinh = DateTime.Now
            //    }
            //};

            #endregion
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var services = new Service();

            listItem = await services.GetChamSocKH(3); 
        }
        #region Refreshing
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    var customersService = new Service();

                    listItem = await customersService.GetChamSocKH(3);

                    IsRefreshing = false;
                });
            }
        }
        #endregion
    }
}
