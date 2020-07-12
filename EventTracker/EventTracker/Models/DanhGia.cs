using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
    public class DanhGia
    {
        public int id { get; set; }
        public string noiDungDanhGia { get; set; }
        public string danhGiaThaiDoNV { get; set; }
        public int mucDoHaiLong { get; set; }
        public DateTime ngayDanhGia { get; set; } = DateTime.Now;
        public int idDatLichHen { get; set; }
    }
}
