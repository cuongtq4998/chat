using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.Models
{
   public class THONGTINDICHVU
    {
        public int ID { get; set; }

        private string _tieuDeDV;
        public string TieuDeDV {
            set
            {
                _tieuDeDV = value; 
            }
            get => _tieuDeDV;
        }

        private string _noiDungDV;
        public string NoiDungDV
        {
            set
            {
                _noiDungDV = value;
            }
            get => _noiDungDV;
        }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public double ChiPhiDV { get; set; }
        //[MaxLength]
        private byte[] _image;
        public byte[] ImageDV {
            set
            { 
                _image = value;
            }
            get => _image;
        }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
