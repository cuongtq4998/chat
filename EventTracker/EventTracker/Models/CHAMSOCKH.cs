using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Models
{
    public class CHAMSOCKH: ObservableObject
    {

        private int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get => _ID;
        }

        private string _tieU_DE;
        public string tieU_DE
        {
            set
            {
                _tieU_DE = value;
            }
            get => _tieU_DE;
        }

        private string _noI_DUNG;
        public string noI_DUNG
        {
            set
            {
                _noI_DUNG = value;
            }
            get => _noI_DUNG;
        }

        private DateTime _thoI_GIAN;
        public DateTime thoI_GIAN
        {
            set
            {
                _thoI_GIAN = value;
            }
            get => _thoI_GIAN;
        }

        private THONGTINDICHVU _thongtindichvu;
        public THONGTINDICHVU thongtindichvu {
            set
            {
                _thongtindichvu = value;
            }
            get => _thongtindichvu;
        }

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

        public CHAMSOCKH(int ID,
                         string tieU_DE,
                         string noI_DUNG,
                         DateTime thoI_GIAN, 
                         THONGTINDICHVU thongtindichvu)
        {
            this._ID = ID;
            this._tieU_DE = tieU_DE;
            this._noI_DUNG = noI_DUNG;
            this._thoI_GIAN = thoI_GIAN;
            this._thongtindichvu = thongtindichvu;

        }
        //public CHAMSOCKH(int ID,
        //                string tieU_DE,
        //                string noI_DUNG,
        //                DateTime thoI_GIAN,
        //                THONGTINDICHVU thongtindichvu,
        //                CHITIETCHAMSOCKH cT_CS_KHs,
        //                USER_ADMIN useR_ADMIN)
        //{
        //    this._ID = ID;
        //    this._tieU_DE = tieU_DE;
        //    this._noI_DUNG = noI_DUNG;
        //    this._thoI_GIAN = thoI_GIAN;
        //    this._thongtindichvu = thongtindichvu;
        //    this.cT_CS_KHs = cT_CS_KHs;
        //    this._useR_ADMIN = useR_ADMIN;

        //}
    }
}
