using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.Models
{
    class PersonDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate KhachHangA { get; set; }

		public DataTemplate KhachHangB { get; set; }

        

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{

            return ((Customers)item).NgaySinh.Date > DateTime.Today ? KhachHangA : KhachHangB ;
		}
	}
}
