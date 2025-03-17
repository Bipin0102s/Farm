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
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UserEntry.Text;
            string password = PasswordEntry.Text;

            var user = await DatabaseHelper.Database.Table<User>()
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                await DisplayAlert("Login", "Login successful!", "OK");
                await Navigation.PushAsync(new MainPage()); // Navigate to the main page
            }
            else
            {
                await DisplayAlert("Login", "Invalid username or password.", "OK");
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Signup());
        }
    }
}