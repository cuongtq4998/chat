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
        public DateTime thoiGianHen { get; set; } = DateTime.Now;
    }
}
