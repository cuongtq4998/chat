using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
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
     class HIENTHITHONGTINViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
         

        private List<Customers> _khachhang;
        public List<Customers> khachhang
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
                    khachhang = vm.khachhangList;
                    IsRefreshing = false;
                });
            }
        }
        #endregion
    }
}
