using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Current.UserAppTheme = OSAppTheme.Light;

            MainPage = new NavigationPage(new MainPage());
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
