using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    public class getDatHenThongTinDichVu
    {
        public DatLichHen DatLichHen { get; set; }
        public THONGTINDICHVU ThongTinDichVu { get; set; }
    }
    class LICHHENCANHANViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<getDatHenThongTinDichVu> _ListHenList;
        public List<getDatHenThongTinDichVu> ListHenList
        {
            get { return _ListHenList; }
            set
            {
                _ListHenList = value;
                OnPropertyChanged();
            }
        }
        public Command ThemLichHen
        {
            get
            {
                return new Command(async =>
                {
                     //
                });
            }
        } 


        int idKH = 0;
        public LICHHENCANHANViewModel()
        { 
            if (Application.Current.Properties.ContainsKey("IdKH"))
            {
                idKH = Convert.ToInt32(Application.Current.Properties["IdKH"].ToString());
            }
            _ = InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            try
            {
                IsRefreshing = true;
                var services = new Service();
                ListHenList = await services.GetLichHen((int)getLinkPage.linkDatLichHen, idKH);
                IsRefreshing = false;
            }
            catch (Exception) { } 
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

                    var services = new Service();
                    ListHenList = await services.GetLichHen((int)getLinkPage.linkDatLichHen, idKH);

                    IsRefreshing = false;
                });
            }
        }
        #endregion
    }
}
