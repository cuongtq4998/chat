using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatBot.ViewModels
{
   public class SetIsSelected: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
         
        bool isSelected;
        public bool IsSelected
        {
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
            get => isSelected;
        }
        string _TieuDeDV;
        public string TieuDeDV
        {
            set
            {
                _TieuDeDV = value;
                OnPropertyChanged();
            }
            get => _TieuDeDV;
        }

        int _IdKH;
        public int IdKH
        {
            set
            {
                _IdKH = value;
                OnPropertyChanged();
            }
            get => _IdKH;
        }
        THONGTINDICHVU _TTDV;
        public THONGTINDICHVU THONGTINDICHVU
        {
            set
            {
                _TTDV = value;
                OnPropertyChanged();
            }
            get => _TTDV;
        }

    }
}
