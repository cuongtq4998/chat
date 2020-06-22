using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
    public  class User_KH
    { 
        public int id { get; set; }
        public string taiKhoan { get; set; } 
        public string matKhau { get; set; }
        public DateTime thoiGianDangNhap { get; set; } = DateTime.Now;
        public bool dangOnline { get; set; } = true;
    }
}
