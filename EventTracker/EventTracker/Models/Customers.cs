using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ChatBot.Models
{
    class Customers
    {  
        public string ID { get; set; } = Path.GetRandomFileName();
        public string HoTen { get; set; }
        public string GioiTinh { get; set; } 
        public DateTime NgaySinh { get; set; } = DateTime.Now; 
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; } 
    }
}
