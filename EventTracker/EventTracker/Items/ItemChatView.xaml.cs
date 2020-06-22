using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Items
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemChatView : ContentView
	{
		public ItemChatView ()
		{
			InitializeComponent ();
		}
	}

    public class ItemChatViewModel
    {
        public string TextChat { get; set; }
        public bool MyChat { get; set; }
    }

}