﻿using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    public class DatLichHenPuss
    {
        public int IDDV { get; set; }
        public int IDKH { get; set; }
        public DatLichHen datLicHen { get; set; }
        
    }
    class DatLichHenViewModell : INotifyPropertyChanged
    {
        public List<SetIsSelected> listTTDV = new List<SetIsSelected>();
        List<Customers> khachhangList = new List<Customers>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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

        //public ObservableCollection<SetIsSelected> Items { set; get; }
        public DatLichHenViewModell()
        {
            getDataAsync();
            InitializeDataAsync(); 
            
        }

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

        
        private async Task InitializeDataAsync()
        {
            var services = new Service();
            dichVuList = await services.GetTTDV(2);
            

            for(int i = 0; i < dichVuList.Count; i++)
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

        public async Task<List<Customers>> getDataAsync()
        {
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
                 khachhangList = await services.GetCustomersWithID(taikhoan, matkhau, 1);
                 
            }
            datLichhen.IDKH = Convert.ToInt32(khachhangList[0].id);
            return khachhangList;
        }
        public Command butonAddData
        {
            get
            {
                return new Command(async () =>
                {
                    var services = new Service(); 
                    await services.DatLichHen(datLichhen, (int)getLinkPage.linkDatLichHen); 
                });
            }
        }

        List<string> _yeuCauHen = new List<string>()
        {
            "Sử dụng dịch vụ",
            "Tư vấn",
            "Khác"
        };
        public List<string> YeuCauHen
        {
            get { return _yeuCauHen; }
            private set
            {
                _yeuCauHen = value;
                OnPropertyChanged();
            }
        }
    }
}
