using ChatBot.Views;
using DayVsNight.Themes;
using EventTracker;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.ABC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TRANGCHUDEMO : ContentPage
    {
        public TRANGCHUDEMO()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // MessagingCenter.Subscribe<LoginMessage>(this, "successful_login", (lm) => HandleLogin(lm));
            MessagingCenter.Subscribe<ThemeMessage>(this, ThemeMessage.ThemeChanged, (tm) => UpdateTheme(tm));
        }

        private void UpdateTheme(ThemeMessage tm)
        {
            BackgroundGradient.InvalidateSurface();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ThemeMessage>(this, ThemeMessage.ThemeChanged);
        }

        string themeName = "dark";  

        private void ProfileImage_Tapped(object sender, EventArgs e)
        {
            if (themeName == "dark")
            {
                themeName = "light";
            }
            else
            {
                themeName = "dark";
            }

            ThemeHelper.ChangeTheme(themeName);
        }

        // background brush
        SKPaint backgroundBrush = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = Color.Tomato.ToSKColor()
        };

        private void BackgroundGradient_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // get the brush based on the theme
            SKColor gradientStart = ((Color)Application.Current.Resources["BackgroundGradientStartColor"]).ToSKColor();
            SKColor gradientMid = ((Color)Application.Current.Resources["BackgroundGradientMidColor"]).ToSKColor();
            SKColor gradientEnd = ((Color)Application.Current.Resources["BackgroundGradientEndColor"]).ToSKColor();

            // gradient backround
            backgroundBrush.Shader = SKShader.CreateRadialGradient
                (new SKPoint(0, info.Height * .8f),
                info.Height * .8f,
                new SKColor[] { gradientStart, gradientMid, gradientEnd },
                new float[] { 0, .5f, 1 },
                SKShaderTileMode.Clamp);

            //backgroundBrush.Shader = SKShader.CreateLinearGradient(
            //                              new SKPoint(0, 0),
            //                              new SKPoint(info.Width, info.Height),
            //                              new SKColor[] {
            //                                  gradientStart, gradientEnd },
            //                              new float[] { 0, 1 },
            //                              SKShaderTileMode.Clamp);
            SKRect backgroundBounds = new SKRect(0, 0, info.Width, info.Height);
            canvas.DrawRect(backgroundBounds, backgroundBrush);


        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new DATLICHHENViewPage());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new THONGBAOViewPage());
        } 

        private void DatLichHenTrigger_Tapped(object sender, EventArgs e)
        {
            OnClickAsync();
        }

        private void ChatTrigger_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChatKNNViewPage());
        }

        private void ThongBaoTrigger_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new THONGBAOViewPage());
        }

        private void ThongTinCaNhanTrigger_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HIENTHITHONGTINViewPage());
        }
         
        private void DanhSachDichVuTrigger_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DanhSachDVPage());
        }

        private void DanhSachLichHenTrigger_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LICHHENCANHANViewPage());
        }

        public async Task OnClickAsync()
        {
            try
            {
                string taikhoan = "";
                string matkhau = "";
                if (Application.Current.Properties.ContainsKey("Taikhoan") && Application.Current.Properties.ContainsKey("Matkhau"))
                {
                    taikhoan = Application.Current.Properties["Taikhoan"].ToString();
                    matkhau = Application.Current.Properties["Matkhau"].ToString();
                }
                if (taikhoan == "" || matkhau == "")
                {
                    bool check = await DisplayAlert("Thông báo", "Bạn chưa có thông tin.  Hãy đăng kí thông tin!", "Chấp nhận", "Hủy");
                    if (check)
                    {
                        _ = Navigation.PushAsync(new DANGKITKViewPage());
                    }
                }
                else
                {
                    _ = Navigation.PushAsync(new DatLichHenDanhSachDichVu());
                }
            }
            catch (Exception) { }
        }
    }
}