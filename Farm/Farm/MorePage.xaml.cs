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
    }
    
}