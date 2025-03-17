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
	public partial class Signup : ContentPage
	{
		public Signup ()
		{
			InitializeComponent ();
		}
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = UserEntry.Text,
                Password = PasswordEntry.Text,
                
            };

            try
            {
                await DatabaseHelper.Database.InsertAsync(user);
                await DisplayAlert("Success", "User registered successfully!", "OK");
                await Navigation.PopAsync(); // Go back to the sign-in page
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to register user: {ex.Message}", "OK");
            }
        }
    }
}