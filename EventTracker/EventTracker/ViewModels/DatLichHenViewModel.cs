using ChatBot.Models;
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
    class DatLichHenPuss
    {
        public int IDDV { get; set; } = 1;
        public int IDKH { get; set; } = 1;
        public DatLichHen lichhen { get; set; }
        
    }
    class DatLichHenViewModell : INotifyPropertyChanged
    {
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
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var services = new Service();
            dichVuList = await services.GetTTDV(2);
            List<SetIsSelected> list = new List<SetIsSelected>();
            //list.Add(new SetIsSelected
            //{
            //    IsSelected = false,
            //    TieuDeDV = dichVuList[0].TieuDeDV,
            //    THONGTINDICHVU = new THONGTINDICHVU
            //    {
            //        ChiPhiDV = dichVuList[0].ChiPhiDV,
            //        TieuDeDV  = dichVuList[0].TieuDeDV,
            //        NoiDungDV = dichVuList[0].NoiDungDV,
            //        ImageDV = dichVuList[0].ImageDV,
            //        CreateDate = DateTime.Now
            //    }
            //});
            //list.Add(new SetIsSelected
            //{
            //    IsSelected = false,
            //    TieuDeDV = dichVuList[0].TieuDeDV,
            //    THONGTINDICHVU = new THONGTINDICHVU
            //    {
            //        ChiPhiDV = dichVuList[0].ChiPhiDV,
            //        TieuDeDV = dichVuList[0].TieuDeDV,
            //        NoiDungDV = dichVuList[0].NoiDungDV,
            //        ImageDV = dichVuList[0].ImageDV,
            //        CreateDate = DateTime.Now
            //    }
            //});

            for(int i = 0; i < dichVuList.Count; i++)
            {
                list.Add(new SetIsSelected
                {
                    IsSelected = false,
                    TieuDeDV = dichVuList[i].TieuDeDV,
                    THONGTINDICHVU = new THONGTINDICHVU
                    {
                        ChiPhiDV = dichVuList[i].ChiPhiDV,
                        TieuDeDV = dichVuList[i].TieuDeDV,
                        NoiDungDV = dichVuList[i].NoiDungDV,
                        ImageDV = dichVuList[i].ImageDV,
                        CreateDate = DateTime.Now
                    }
                });
            }
            Items = list;
        }

        

        private DatLichHenPuss _datLichHen = new DatLichHenPuss();
        public DatLichHenPuss datLichhen
        {
            get { return _datLichHen; }
            set
            {
                datLichhen = value;
            }
        }

        public Command butonAddData
        {
            get
            {
                return new Command(async () =>
                {
                    var services = new Service();
                    await services.DatLichHen(_datLichHen, (int)getLinkPage.linkDatLichHen); 
                });
            }
        } 
    }
}
