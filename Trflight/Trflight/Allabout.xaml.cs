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
        public Allabout()
        {
            InitializeComponent();
        }

        bool topison = true;
        bool cntrison = true;
        bool btmison = true;
        bool autobtnison = true;

        void AutoScript()
        {
            top.Opacity = 1;
            Thread.Sleep(4000);
            cntr.Opacity = 1;
            Thread.Sleep(4000); 
            btm.Opacity = 1;
        }

        private void top_Clicked(object sender, EventArgs e)
        {
            topison = !topison;
            if (autobtnison == true) { if (topison == false) { top.Opacity = 0.5; } else { top.Opacity = 1; } }
        }

        private void cntr_Clicked(object sender, EventArgs e)
        {
            cntrison = !cntrison;
            if (autobtnison == true) { if (cntrison == false) { cntr.Opacity = 0.5; } else { cntr.Opacity = 1; } } 
        }

        private void btm_Clicked(object sender, EventArgs e)
        {
            btmison = !btmison;
            if (autobtnison == true) { if (btmison == false) { btm.Opacity = 0.5; } else { btm.Opacity = 1; } }
        }

        private void autobtn_Clicked(object sender, EventArgs e)
        {
            autobtnison = !autobtnison;
            if (autobtnison == false) {
                // Double tapping bug fix
                autobtnison = true;
                autobtn.Opacity = 0.5;
                if (top.Opacity == 1) { top_Clicked(top, e); };
                if (cntr.Opacity == 1) { cntr_Clicked(cntr, e); };
                if (btm.Opacity == 1) { btm_Clicked(btm, e); };
                autobtnison = false;
                top.IsEnabled = false;
                cntr.IsEnabled = false;
                btm.IsEnabled = false;

                // Watchlight auto function
                AutoScript(); 
            } else { 
                autobtn.Opacity = 1;
                top.IsEnabled = true;
                cntr.IsEnabled = true;
                btm.IsEnabled = true;
            }
        }
    }
}