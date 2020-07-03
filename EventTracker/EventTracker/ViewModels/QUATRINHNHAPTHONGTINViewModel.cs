using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.Services;
using ChatBot.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    class AddUser
    {
        public int ID { get; set; }

        public string HoTen { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; } = DateTime.Now;

        public string NgheNghiep { get; set; }

        public string DienThoai { get; set; }

        public string DiaChi { get; set; }

        public string Email { get; set; }

        public DatLichHen datLichHen { get; set; }

        public List<User_KH> user_KH ; 

        public CHITIETCHAMSOCKH _cT_CS_KH { get; set; }
    }
    class QUATRINHNHAPTHONGTINViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
  
        private AddUser _SelectedCustomers = new AddUser();
        public string Message { get; set; }
        public AddUser SelectedCustomers
        {
            get { return _SelectedCustomers; }
            set
            {
                SelectedCustomers = value;
            }
        }
        public Command AddInforCus
        { 
            get
            {
                return new Command( async () =>
                {
                    var services = new Service(); 
                    await services.PostCustomers(_SelectedCustomers, (int)getLinkPage.linkKhachHang); 

                });
            }
        }
         
        //----------
        List<string> _NgheNghiep = new List<string>()
        {
            "Học Sinh/Sinh Viên",
            "Công Nghệ Thông Tin",
            "Buôn Bán",
            "Khác"
        };
        public List<string> ListNgheNghiep
        {
            get { return _NgheNghiep; }
            private set
            {
                _NgheNghiep = value;
                OnPropertyChanged();
            }
        }
        //-------------------
        List<string> _GioiTinh = new List<string>()
        {
            "Nam",
            "Nữ",
            "Khác"
        };
        public List<string> ListGioiTinh
        {
            get { return _GioiTinh; }
            private set
            {
                _GioiTinh = value;
                OnPropertyChanged();
            }
        }

        
    }
    //private User_KH _loginAccount;
    //public User_KH LoginAccont
    //{
    //    get
    //    {
    //        return _loginAccount;
    //    }

    //    set
    //    {
    //        _loginAccount = value;
    //        Debug.WriteLine(_loginAccount);
    //    }
    //}
}
