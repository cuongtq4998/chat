using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
   public  class DatLichHen
    {
        public int ID { get; set; }
        public string tieuDe { get; set; }
        public string noiDung { get; set; }
        public DateTime BatDauHen { get; set; }
        public DateTime KetThucHen { get; set; }
        public int ThoiGianNhacNho { get; set; }
    }
}
