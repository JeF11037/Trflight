using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trflight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Allabout : ContentPage
    {
        public Button tp, cr, bm, bn;
        public Frame tpFrame, crFrame, bmFrame, bnFrame;
        public BoxView box;


        public Allabout()
        {
            //InitializeComponent();

            tp = new Button()
            {
                BackgroundColor = Color.Red,
                WidthRequest = 160,
                HeightRequest = 160,
                CornerRadius = 80,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
            };
            tp.Clicked += Tp_Clicked;

            cr = new Button()
            {
                BackgroundColor = Color.Yellow,
                WidthRequest = 160,
                HeightRequest = 160,
                CornerRadius = 80,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
            };
            cr.Clicked += Cr_Clicked;

            bm = new Button()
            {
                BackgroundColor = Color.Green,
                WidthRequest = 160,
                HeightRequest = 160,
                CornerRadius = 80,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
            };
            bm.Clicked += Bm_Clicked;

            bn = new Button()
            {
                BackgroundColor = Color.Blue,
                WidthRequest = 160,
                HeightRequest = 160,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
            };
            bn.Clicked += Bn_Clicked;

            tpFrame = new Frame()
            {
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center,
                Content = tp
            };

            crFrame = new Frame()
            {
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center,
                Content = cr
            };

            bmFrame = new Frame()
            {
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center,
                Content = bm
            };

            box = new BoxView()
            {
                BackgroundColor = Color.White,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
            };

            StackLayout st = new StackLayout()
            {
                Children = { tpFrame, crFrame, bmFrame, box, bn}
            };
            Content = st;
        }

        bool topison = true;
        bool cntrison = true;
        bool btmison = true;
        bool autobtnison = true;

        void AutoScript()
        {
            tp.Opacity = 1;
            Thread.Sleep(4000);
            cr.Opacity = 1;
            Thread.Sleep(4000);
            bm.Opacity = 1;
        }

        private void Bn_Clicked(object sender, EventArgs e)
        {
            autobtnison = !autobtnison;
            if (autobtnison == false)
            {
                // Double tapping bug fix
                autobtnison = true;
                bn.Opacity = 0.5;
                if (tp.Opacity == 1) { Tp_Clicked(tp, e); };
                if (cr.Opacity == 1) { Cr_Clicked(cr, e); };
                if (bm.Opacity == 1) { Bm_Clicked(bm, e); };
                autobtnison = false;
                tp.IsEnabled = false;
                cr.IsEnabled = false;
                bm.IsEnabled = false;

                // Watchlight auto function
                //AutoScript();
            }
            else
            {
                bn.Opacity = 1;
                tp.IsEnabled = true;
                cr.IsEnabled = true;
                bm.IsEnabled = true;
            }
        }

        private void Bm_Clicked(object sender, EventArgs e)
        {
            btmison = !btmison;
            if (autobtnison == true) { if (btmison == false) { bm.Opacity = 0.5; } else { bm.Opacity = 1; } }
        }

        private void Cr_Clicked(object sender, EventArgs e)
        {
            cntrison = !cntrison;
            if (autobtnison == true) { if (cntrison == false) { cr.Opacity = 0.5; } else { cr.Opacity = 1; } }
        }

        private void Tp_Clicked(object sender, EventArgs e)
        {
            topison = !topison;
            if (autobtnison == true) { if (topison == false) { tp.Opacity = 0.5; } else { tp.Opacity = 1; } }
        }
    }
}