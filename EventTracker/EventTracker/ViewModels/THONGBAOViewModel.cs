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
    public class ketnoiDLH_TTDV
    {
        public DatLichHen datLichHen { get; set; }
        public THONGTINDICHVU ttdv { get; set; }
        public Customers khachHang { get; set; }
    }
    public class ThongTinChamSocKH
    {
        public ObservableCollection<CHAMSOCKH> chamsockhachhang { get; set; }
        public ObservableCollection<ketnoiDLH_TTDV> ketnoiDLH_DV { get; set; }
    }
    class THONGBAOViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<ThongTinChamSocKH> _items;
        public List<ThongTinChamSocKH> listItem
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CHAMSOCKH> _khachhang;
        public ObservableCollection<CHAMSOCKH> khachhang
        {
            get { return _khachhang; }
            set
            {
                _khachhang = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public THONGBAOViewModel()
        {   
            InitializeDataAsync();
        }

        public async Task InitializeDataAsync()
        {
            IsRefreshing = true;
            var services = new Service();

            listItem = await services.GetChamSocKH(3);
            khachhang = listItem[0].chamsockhachhang;
            IsRefreshing = false;
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
