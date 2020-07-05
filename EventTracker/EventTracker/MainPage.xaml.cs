using ChatBot.Models;
using ChatBot.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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
            try
            {
                string Taikhoan = (string)Application.Current.Properties["Taikhoan"];
                string Matkhau = (string)Application.Current.Properties["Matkhau"];
                if (Taikhoan != null && Matkhau != null)
                {
                    nameUser.Text = "HI!" + Taikhoan; 
                    Logout.Text = "Đăng xuất";
                }
                else
                {
                    nameUser.Text = "Bạn đã có tài khoản chưa?"; 
                    Logout.Text = "Đăng nhập";
                }
            }
            catch (Exception) { Debug.WriteLine("Error"); }
           

            menuList = new List<ItemMenu>();

            var dichVu = new ItemMenu()
            {
                title = "Trang chủ",
                icon = "tick.png",
                TagetType = typeof(DanhSachDVPage)
            };
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
            
            var tt = new ItemMenu()
            {
                title = "Thông tin cá nhân",
                icon = "tick.png",
                TagetType = typeof(HIENTHITHONGTINViewPage)
            }; 
            var rating = new ItemMenu()
            {
                title = "Đánh giá",
                icon = "tick.png",
                TagetType = typeof(RatingViewPage)
            };

            menuList.Add(dichVu);
            menuList.Add(Dangkitaikhoan);
            menuList.Add(ChatwithDiaflow); 
            menuList.Add(tt); 
            menuList.Add(rating);
             
            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DanhSachDVPage)));
        } 

        public List<ItemMenu> menuList { get; set; }
        private void navigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (ItemMenu)e.SelectedItem;
            Type page = item.TagetType;

            try
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }catch(Exception) { }
            
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            try
            {
                string Taikhoan = (string)Application.Current.Properties["Taikhoan"];
                string Matkhau = (string)Application.Current.Properties["Matkhau"];
                if (Taikhoan != null && Matkhau != null)
                {
                    Application.Current.Properties["Taikhoan"] = null;
                    Application.Current.Properties["Matkhau"] = null;
                    nameUser.Text = "HI!" + Application.Current.Properties["Taikhoan"];
                    IsPresented = false;
                }
                else
                {
                    try
                    {
                        Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(LOGIN)));
                        IsPresented = false;
                    }
                    catch (Exception) { } 
                }
            }
            catch (Exception) { Debug.WriteLine("Error"); }
        }
    } 
}
