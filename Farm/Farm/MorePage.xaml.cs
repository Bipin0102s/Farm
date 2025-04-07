using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Farm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

            private void HomeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "Cancel");
            if (confirm)
            {
                // Optional: clear user session or stored data
                // Application.Current.Properties.Clear();

                // Navigate to LoginPage (or any other start page)
                Application.Current.MainPage = new NavigationPage(new SignInPage());
            }
        }


        private void CollectionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CollectionPage());
        }

        private void SellButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SellPage());
        }

        private void MoreButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MorePage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DatabaseExporter.ShareDatabaseFileAsync();
        }
    }
    
}