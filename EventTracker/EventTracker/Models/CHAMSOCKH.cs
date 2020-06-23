using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
    public class CHAMSOCKH
    {
        public int ID { get; set; }
        public string tieU_DE { get; set; }
        public string noI_DUNG { get; set; }
        public DateTime thoI_GIAN { get; set; } = DateTime.Now;
         
        public THONGTINDICHVU thongtindichvu { get; set; }

        private USER_ADMIN _useR_ADMIN;
        USER_ADMIN useR_ADMIN
        {
            set
            {
                _useR_ADMIN = value;
            }
            get => _useR_ADMIN;
        }
        private CHITIETCHAMSOCKH _cT_CS_KHs;
        CHITIETCHAMSOCKH cT_CS_KHs
        {
            set
            {
                _cT_CS_KHs = value;
            }
            get => _cT_CS_KHs;
        }
    }
}
