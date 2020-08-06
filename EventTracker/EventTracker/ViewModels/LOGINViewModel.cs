using ChatBot.Models;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.ViewModels
{
    class LOGINViewModel : INotifyPropertyChanged
    {
        public Customers itemKhachHang { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private User_KH _checkLogin = new User_KH(); 
        public User_KH checkLogin
        {
            get { return _checkLogin; }
            set
            {
                checkLogin = value;
            }
        }
        public Command loginAccount
        {
            get
            {
                return new Command(async () =>
                {
                    int gioiTinhNam = 1;
                    int gioiTinhNu = 0;
                    var services = new Service();
                    itemKhachHang = await services.GetCustomersWithID(checkLogin.taiKhoan, checkLogin.matKhau, 1);

                    if(itemKhachHang != null)
                    {
                        Application.Current.Properties["Taikhoan"] = checkLogin.taiKhoan;
                        Application.Current.Properties["Matkhau"] = checkLogin.matKhau;
                        Application.Current.Properties["IdKH"] = itemKhachHang.id; 

                        if(itemKhachHang.GioiTinh == "Nam")
                        {
                            Application.Current.Properties["gioitinh"] = gioiTinhNam;
                        }
                        else
                        {
                            Application.Current.Properties["gioitinh"] = gioiTinhNu;
                        }
                        

                        await Application.Current.SavePropertiesAsync();
                    }
                    else
                    {
                        Debug.Write("Error. ");
                    }
                });
            }
        }

    }
}
