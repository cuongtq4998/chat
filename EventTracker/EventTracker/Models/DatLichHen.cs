using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
   public  class DatLichHen
    {
        public int ID { get; set; }
        public string YeuCau { get; set; }
        public DateTime ThoiGianHen { get; set; }
        public DateTime NgayTao { get; set; }
        public int ThoiGianNhacNho { get; set; }
        public int TrangThaiLichHen { get; set; }
        public string NoiDungHuy { get; set; }
    }
}
