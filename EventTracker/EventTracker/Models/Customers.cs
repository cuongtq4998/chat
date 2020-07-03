using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ChatBot.Models
{
    public class Customers
    {  
        public string id { get; set; } 
        public string HoTen { get; set; }
        public string GioiTinh { get; set; } 
        public DateTime NgaySinh { get; set; } = DateTime.Now;
        public string NgheNghiep { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; } 
        public IList<DatLichHen> DatLichHen { get; set; }
        public IList<User_KH> User_KH { get; set; }
         IList<CHITIETCHAMSOCKH> CT_CS_KHs { get; set; }
    }
}
