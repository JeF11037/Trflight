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
        public Frame tpFrame, crFrame, bmFrame, bnFrame, ltFrame;
        public BoxView box;


        public Allabout()
        {
            //InitializeComponent();

            tp = new Button()
            {
                BackgroundColor = Color.Red,
                WidthRequest = 80,
                HeightRequest = 80,
                CornerRadius = 40,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
                Opacity = 0.5
            };
            tp.Clicked += Tp_Clicked;

            cr = new Button()
            {
                BackgroundColor = Color.Yellow,
                WidthRequest = 80,
                HeightRequest = 80,
                CornerRadius = 40,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
                Opacity = 0.5
            };
            cr.Clicked += Cr_Clicked;

            bm = new Button()
            {
                BackgroundColor = Color.Green,
                WidthRequest = 80,
                HeightRequest = 80,
                CornerRadius = 40,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BorderWidth = 2,
                Opacity = 0.5
            };
            bm.Clicked += Bm_Clicked;

            bn = new Button()
            {
                BackgroundColor = Color.Blue,
                WidthRequest = 80,
                HeightRequest = 80,
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
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
            };

            StackLayout st = new StackLayout()
            {
                Children = { tpFrame, crFrame, bmFrame, box, bn}
            };

            while (true)
            {
                Frame grass = new Frame() { VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Green };
                st.Children.Add(grass);
                break;
            }

            Content = st;
        }

        bool topison = false;
        bool cntrison = false;
        bool btmison = false;
        bool autobtnison = true;

        int puton = 0;

        void LightOn()
        {
            if (topison) { tp.Opacity = 1; cr.Opacity = 0.5; bm.Opacity = 0.5; };
            if (cntrison) { tp.Opacity = 0.5; cr.Opacity = 1; bm.Opacity = 0.5; };
            if (btmison) { tp.Opacity = 0.5; cr.Opacity = 0.5; bm.Opacity = 1; };
        }

        private void Bm_Clicked(object sender, EventArgs e)
        {
            if(btmison == false) { btmison = !btmison; topison = false; cntrison = false; }
            LightOn();
        }

        private void Cr_Clicked(object sender, EventArgs e)
        {
            if (cntrison == false) { cntrison = !cntrison; topison = false; btmison = false; }
            LightOn();
        }

        private void Tp_Clicked(object sender, EventArgs e)
        {
            if (topison == false) { topison = !topison; cntrison = false; btmison = false; }
            LightOn();
        }

        async void Auto(EventArgs e)
        {
            while (autobtnison)
            {
                await Task.Delay(1000);
                if (puton == 0) { Bm_Clicked(bm, e); }
                else if (puton == 1) { Cr_Clicked(cr, e); }
                else if (puton == 2) { Tp_Clicked(tp, e); }
                else if (puton == 3) { Cr_Clicked(cr, e); puton = -1; }
                puton++;
            }
        }

        private void Bn_Clicked(object sender, EventArgs e)
        {
            autobtnison = !autobtnison;
            if (autobtnison) { Auto(e); }
        }
    }
}