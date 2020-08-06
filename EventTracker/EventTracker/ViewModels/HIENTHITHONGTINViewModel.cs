using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using ChatBot.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
     public class HIENTHITHONGTINViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Customers _khachhang;
        public Customers khachhang
        {
            get { return _khachhang; }
            set
            {
                _khachhang = value;
                OnPropertyChanged();
            }
        }
        public HIENTHITHONGTINViewModel()
        { 
            _ = getDataAsync(); 
        }
        
        public async Task getDataAsync()
        {
            IsRefreshing = true;
            string taikhoan = "";
            string matkhau = "";
            if (Application.Current.Properties.ContainsKey("Taikhoan") && Application.Current.Properties.ContainsKey("Matkhau"))
            {
                taikhoan = Application.Current.Properties["Taikhoan"].ToString();
                matkhau = Application.Current.Properties["Matkhau"].ToString();
            }
            var services = new Service();

            if (taikhoan != null && matkhau != null)
            {
                khachhang = await services.GetCustomersWithID(taikhoan, matkhau, 1); 

            }
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

                    //khachhang = await customersService.GetCustomersWithID(1, (int)getLinkPage.linkKhachHang);

                    var vm = new  LOGINViewModel();
                    khachhang = vm.itemKhachHang;
                    IsRefreshing = false;
                });
            }
        }
        #endregion
    }
}
