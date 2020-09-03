using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trflight
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Allabout();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
