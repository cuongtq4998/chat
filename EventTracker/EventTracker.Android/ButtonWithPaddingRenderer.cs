using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatBot.Controls;
using ChatBot.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonWithPadding), typeof(ButtonWithPaddingRenderer))]
namespace ChatBot.Droid
{
    public class ButtonWithPaddingRenderer: ButtonRenderer
    {
        public ButtonWithPaddingRenderer(Context c) : base(c) { }
        private void UpdatePadding()
        {
            ButtonWithPadding buttonWithPadding = Element as ButtonWithPadding;

            if (buttonWithPadding != null && buttonWithPadding.Padding.Left > 0)
            {
                Control.SetPadding(
                    (int)buttonWithPadding.Padding.Left,
                    (int)buttonWithPadding.Padding.Top,
                    (int)buttonWithPadding.Padding.Right,
                    (int)buttonWithPadding.Padding.Bottom
                );
            }
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            UpdatePadding();
            var button = this.Control;
            button.SetAllCaps(false);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(ButtonWithPadding.Padding))
                UpdatePadding();
        }

    }
}