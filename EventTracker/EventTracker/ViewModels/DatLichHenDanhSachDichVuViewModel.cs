using ChatBot.Models;
using ChatBot.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatBot.ViewModels
{
    class DatLichHenDanhSachDichVuViewModel : INotifyPropertyChanged
    {
        DatLichHenPuss _datLichHen = new DatLichHenPuss()
        {
            datLicHen = new DatLichHen
            {
                YeuCau = "",
                ThoiGianHen = DateTime.Now,
                NgayTao = DateTime.Now,
                ThoiGianNhacNho = 1
            }
        };
        public DatLichHenPuss datLichhen
        {
            get { return _datLichHen; }
            set
            {
                _datLichHen = value;
            }
        }
        public DatLichHenDanhSachDichVuViewModel()
        {
            _ = InitializeDataAsync();
        }


        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public List<SetIsSelected> listTTDV = new List<SetIsSelected>();
        private ObservableCollection<THONGTINDICHVU> _dichVuList;
        public ObservableCollection<THONGTINDICHVU> dichVuList
        {
            get { return _dichVuList; }
            set
            {
                _dichVuList = value;
                OnPropertyChanged();
            }
        }

        private List<SetIsSelected> _Items;
        public List<SetIsSelected> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                OnPropertyChanged();
            }
        }

        private async Task InitializeDataAsync()
        {
            IsRefreshing = true;
            var services = new Service();
            dichVuList = await services.GetTTDV(2);

            IsRefreshing = false;
            for (int i = 0; i < dichVuList.Count; i++)
            {
                listTTDV.Add(new SetIsSelected
                {
                    IsSelected = false,
                    TieuDeDV = dichVuList[i].TieuDeDV,
                    THONGTINDICHVU = new THONGTINDICHVU
                    {
                        ID = dichVuList[i].ID,
                        ChiPhiDV = dichVuList[i].ChiPhiDV,
                        TieuDeDV = dichVuList[i].TieuDeDV,
                        NoiDungDV = dichVuList[i].NoiDungDV,
                        ImageDV = dichVuList[i].ImageDV,
                        CreateDate = DateTime.Now
                    }
                });
            }
           
            Items = listTTDV;

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

        //public ICommand RefreshCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            IsRefreshing = true;

        //            var customersService = new Service(); 

        //            var vm = new LOGINViewModel();
        //            khachhang = vm.itemKhachHang;
        //            IsRefreshing = false;
        //        });
        //    }
        //}
        #endregion
    }
}
