using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    class LICHHENCANHANViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private List<Customers> _items;
        public List<Customers> listItem
        {
            get { return _items; }
            set
            {

                _items = value;
                OnPropertyChanged();
            }
        }
        public LICHHENCANHANViewModel()
        {
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);
            Random random = new Random();
            listItem = new List<Customers>
            {
                new Customers
                {
                    ID = Path.GetRandomFileName(),
                    HoTen = "Trần Quốc " + random.Next( 1,30),
                    DiaChi = "Thành Phố Hồ Chí Minh",
                    DienThoai = "",
                    GioiTinh = "Nam",
                    Email = "",
                    NgaySinh = today
                },
                new Customers
                {
                    ID =Path.GetRandomFileName(),
                    HoTen = "Trần Quốc " + random.Next( 1,30),
                    DiaChi = "Lê Trọng Tấn,  Sơn Kì, Tần Phú",
                    DienThoai = "9",
                    GioiTinh = "Nam",
                    Email = "",
                    NgaySinh = tomorrow
                },
                new Customers
                {
                    ID = Path.GetRandomFileName(),
                    HoTen = "Trần Quốc " + random.Next( 1,30),
                    DiaChi = "Thành Phố Hồ Chí Minh",
                    DienThoai = "",
                    GioiTinh = "Nam",
                    Email = "",
                    NgaySinh = DateTime.Now
                },
                new Customers
                {
                    ID = Path.GetRandomFileName(),
                    HoTen = "Trần Quốc " + random.Next( 1,30),
                    DiaChi = "Lê Trọng Tấn,  Sơn Kì, Tần Phú",
                    DienThoai = "",
                    GioiTinh = "Nam",
                    Email = "",
                    NgaySinh = DateTime.Now
                }
            };
        }
    }
}
