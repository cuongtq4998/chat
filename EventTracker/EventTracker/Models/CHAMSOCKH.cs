using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
    class CHAMSOCKH
    {
        public int ID { get; set; }
        public string TIEU_DE { get; set; }
        public string NOI_DUNG { get; set; }
        public DateTime THOI_GIAN { get; set; } = DateTime.Now;
         
        public THONGTINDICHVU thongtindichvu { get; set; }  
        public USER_ADMIN useR_ADMIN { get; set; }
        public CHITIETCHAMSOCKH cT_CS_KHs { get; set; }  
    }
}
