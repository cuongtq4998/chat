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
    public class DatLichHenPuss
    {
        public int IDDV { get; set; }
        public int IDKH { get; set; }
        public DatLichHen datLicHen { get; set; }
        
    }
    public class DatLichHenViewModell : INotifyPropertyChanged
    {
        public bool checknavigate { get; set; } = false;
        Customers itemKhachHang = new Customers();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        ////public ObservableCollection<SetIsSelected> Items { set; get; }
        //public ObservableCollection<Appointment> Appointments { get; set; }
        //public DatLichHenViewModell()
        //{
        //    _ = getDataAsync();
        //    //InitializeDataAsync(); 

        //    var date = DateTime.Today;
        //    this.Appointments = new ObservableCollection<Appointment>
        //    {
        //        new Appointment {
        //            Title = "Meeting with Tom",
        //            Detail = "Sea Garden",
        //            StartDate = date.AddHours(10),
        //            EndDate = date.AddHours(11),
        //            Color = Color.Tomato
        //        },
        //        new Appointment {
        //            Title = "Lunch with Sara",
        //            Detail = "Restaurant",
        //            StartDate = date.AddHours(12).AddMinutes(30),
        //            EndDate = date.AddHours(14),
        //            Color = Color.DarkTurquoise
        //        },
        //        new Appointment {
        //            Title = "Elle Birthday",
        //            StartDate = date,
        //            EndDate = date.AddHours(11),
        //            Color = Color.Orange,
        //            IsAllDay = true
        //        },
        //         new Appointment {
        //            Title = "Football Game",
        //            StartDate = date.AddDays(2).AddHours(15),
        //            EndDate = date.AddDays(2).AddHours(17),
        //            Color = Color.Green
        //        }
        //    };

        //}

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

        List<THONGTINDICHVU> _thongtindichvu = new List<THONGTINDICHVU>();
        public List<THONGTINDICHVU> thongtindichvu
        {
            get { return _thongtindichvu; }
            set
            {
                _thongtindichvu = value;
            }
        }
        private TimeSpan _timeSpan;

        public TimeSpan MyTimeSpanProperty // make visible
        {
            get { return _timeSpan; } // put a breakpoint here
            set { _timeSpan = value; } // put a breakpoint here
        }

        public TimeSpan thoigian
        {
            get;
            set;

        }


        public async Task<Customers> getDataAsync()
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
                itemKhachHang = await services.GetCustomersWithID(taikhoan, matkhau, 1);

            }
            datLichhen.IDKH = Convert.ToInt32(itemKhachHang.id);
            return itemKhachHang;
        }
        public Command butonAddData
        {
            get
            {
                return new Command(async () =>
                {

                    if(datLichhen.datLicHen.ThoiGianHen <= DateTime.Now)
                    {
                        checknavigate = false;
                        await Application.Current.MainPage.DisplayAlert("Thông báo", "Ngày hẹn của quý khách không hợp lệ!", "OK");
                    }
                    else if(datLichhen.datLicHen.YeuCau.Equals(string.Empty))
                    {
                        checknavigate = false;
                        await Application.Current.MainPage.DisplayAlert("Thông báo", "Mời bạn chọn yêu cầu hẹn!", "OK");
                    }
                    else
                    {
                        checknavigate = true;
                        TimeSpan thoigian = thoigian;
                        var services = new Service();
                        await services.DatLichHen(datLichhen, (int)getLinkPage.linkDatLichHen);
                        
                        
                    }
                    
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

        List<int> _thoigiannhacnho = new List<int>()
        {
            5,
            10,
            15
        };
        public List<int> thoigiannhacnho
        {
            get { return _thoigiannhacnho; }
            private set
            {
                _thoigiannhacnho = value;
                OnPropertyChanged();
            }
        }
    }
}
