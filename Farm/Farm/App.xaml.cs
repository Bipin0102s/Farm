using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Farm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SignInPage();
            MainPage = new NavigationPage(new SignInPage());
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
