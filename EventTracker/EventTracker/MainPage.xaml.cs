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
            var Dangkitaikhoan = new ItemMenu()
            {
                title = "Đăng ký thông tin",
                icon = "registration.png",
                TagetType = typeof(DANGKITKViewPage)
            };
            var ChatwithDiaflow = new ItemMenu()
            {
                title = "Chat với Diaflow",
                icon = "chatdl.png",
                TagetType = typeof(CHATViewPage)
            };
            var dichVu = new ItemMenu()
            {
                title = "Gói Dịch Vụ",
                icon = "tick.png",
                TagetType = typeof(DanhSachDVPage)
            };
            menuList.Add(Dangkitaikhoan);
            menuList.Add(ChatwithDiaflow);
            menuList.Add(dichVu);
             
            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DanhSachDVPage)));
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
