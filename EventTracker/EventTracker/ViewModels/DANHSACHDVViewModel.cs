using ChatBot.Models;
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
    class DANHSACHDVViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
        private ObservableCollection<THONGTINDICHVU> _dichVuList; 
        public ObservableCollection<THONGTINDICHVU> dichVuList
        {
            get
            { 
                return _dichVuList;
            }
            set
            {
                _dichVuList = value;
                OnPropertyChanged();
            }
        }
         

        public DANHSACHDVViewModel()
        {
             InitializeDataAsync();

            
        } 
        private async Task InitializeDataAsync()
        {
            var services = new Service();

            dichVuList = await services.GetTTDV(2); 
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

                    dichVuList = await customersService.GetTTDV(2);

                    IsRefreshing = false;
                });
            }
        }
        #endregion

    }
}
