using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
    public class NoiDungDanhGiaClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
