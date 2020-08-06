using ChatBot.Models; 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatBot.ViewModels
{
    public class ChiTietLichHenViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //public int trangThaiLichHen;
        //private DatLichHen _DatLichHen = new DatLichHen(); 
        //public DatLichHen datLichHen
        //{
        //    get { return _DatLichHen; }
        //    set
        //    {
        //        datLichHen = value;
        //    }
        //}

        private DatLichHen _loginAccount;
        public DatLichHen LoginAccont
        {
            get
            {
                return _loginAccount;
            }

            set
            {
                _loginAccount = value;
                Debug.WriteLine(_loginAccount);
            }
        }
    }
}
