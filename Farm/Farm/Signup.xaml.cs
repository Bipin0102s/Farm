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
        private void OnSignUpClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sign Up", "Account created successfully!", "OK");
            Navigation.PushAsync(new SignInPage());
        }
    }
}