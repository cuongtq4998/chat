using ChatBot.Models;
using ChatBot.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventTracker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            menuList = new List<ItemMenu>();
            var Home = new ItemMenu()
            {
                title = "Trang Chủ",
                icon = "",
                TagetType = typeof(TRANGCHUviewPage)
            };
            var Dangkitaikhoan = new ItemMenu()
            {
                title = "Đăng Ký",
                icon = "",
                TagetType = typeof(DANGKITKViewPage)
            };
            var ChatwithDiaflow = new ItemMenu()
            {
                title = "Chat với Diaflow",
                icon = "",
                TagetType = typeof(CHATViewPage)
            };

            menuList.Add(Home);
            menuList.Add(Dangkitaikhoan);
            menuList.Add(ChatwithDiaflow);
             
            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TRANGCHUviewPage)));
        } 

        public List<ItemMenu> menuList { get; set; }
        private void navigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (ItemMenu)e.SelectedItem;
            Type page = item.TagetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    } 
}
