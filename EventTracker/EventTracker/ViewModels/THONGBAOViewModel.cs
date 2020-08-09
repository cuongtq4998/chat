using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using MvvmHelpers;
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
    public class ketnoiDLH_TTDV: ObservableObject
    {
        public DatLichHen datLichHen { get; set; }
        public THONGTINDICHVU ttdv { get; set; }
        public Customers khachHang { get; set; }
        public int IdDanhGia { get; set; }


        public ketnoiDLH_TTDV(DatLichHen datLichHen , THONGTINDICHVU ttdv, Customers khachHang, int idDanhGia)
        {
            this.datLichHen = datLichHen;
            this.ttdv = ttdv;
            this.khachHang = khachHang;
            this.IdDanhGia = idDanhGia;
        }
    }
    class ThongTinChamSocKH
    {
        private ObservableCollection<CHAMSOCKH> _chamsockhachhang;
        public ObservableCollection<CHAMSOCKH> chamsockhachhang {
            set
            {
                _chamsockhachhang = value;
            }
            get => _chamsockhachhang;
        }
        public ObservableCollection<ketnoiDLH_TTDV> ketnoiDLH_DV { get; set; }
    }
    class THONGBAOViewModel : INotifyPropertyChanged
    {
        int idKH = 0;
        int gioitinh = 1;
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

        private ObservableCollection<ObservableObject> _ItemModelObject;
        public ObservableCollection<ObservableObject> ItemModelObject
        {
            get { return _ItemModelObject; }
            set
            {
                _ItemModelObject = value;
                OnPropertyChanged();
            }
        } 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public THONGBAOViewModel()
        {
            try
            {

            }catch(Exception e) { Debug.WriteLine("Error"); }
            if (Application.Current.Properties.ContainsKey("IdKH") && Application.Current.Properties.ContainsKey("gioitinh"))
            {
                idKH = Convert.ToInt32(Application.Current.Properties["IdKH"].ToString());
                gioitinh = Convert.ToInt32(Application.Current.Properties["gioitinh"].ToString());
            }
            _ = InitializeDataAsync();
        }

        public async Task InitializeDataAsync()
        {
            IsRefreshing = true;
            var services = new Service();
           
            
            listItem = await services.GetChamSocKH(3, idKH, gioitinh);
            
            ItemModelObject = new ObservableCollection<ObservableObject>();

            for (int i = 0; i < listItem[0].chamsockhachhang.Count; i++)
            {
                ItemModelObject.Add(new CHAMSOCKH(
                    listItem[0].chamsockhachhang[i].ID,
                    listItem[0].chamsockhachhang[i].tieU_DE,
                    listItem[0].chamsockhachhang[i].noI_DUNG,
                    listItem[0].chamsockhachhang[i].thoI_GIAN,
                    listItem[0].chamsockhachhang[i].thongtindichvu));
            }
            if(listItem[0].ketnoiDLH_DV != null)
            {
                for (int i = 0; i < listItem[0].ketnoiDLH_DV.Count; i++)
                {
                    ItemModelObject.Add(new ketnoiDLH_TTDV(
                        listItem[0].ketnoiDLH_DV[i].datLichHen,
                        listItem[0].ketnoiDLH_DV[i].ttdv,
                        listItem[0].ketnoiDLH_DV[i].khachHang,
                        listItem[0].ketnoiDLH_DV[i].IdDanhGia
                        ));
                }
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
                    
                    listItem = await customersService.GetChamSocKH(3, idKH,gioitinh);

                    IsRefreshing = false;
                });
            }
        }
        #endregion
    }
}
