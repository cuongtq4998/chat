using ChatBot.Models;
using ChatBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatBot
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate templateDatLichHen { get; set; }
        public DataTemplate templateChamSocKH { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ketnoiDLH_TTDV)
            {
                return templateDatLichHen;
            }
            if (item is CHAMSOCKH)
            {
                return templateChamSocKH;
            }
                throw new NotImplementedException();
        }
    }
}
