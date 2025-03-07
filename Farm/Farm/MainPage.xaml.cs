using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Farm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllCrops());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage());
        }
    }
}
