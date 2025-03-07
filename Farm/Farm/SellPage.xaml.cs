using System;
using Xamarin.Forms;

namespace Farm
{
    public partial class SellPage : ContentPage
    {
        public SellPage()
        {
            InitializeComponent();
        }

        // Submit Button Clicked
        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            string cropName = CropNameEntry.Text;
            string quantity = CropQuantityEntry.Text;
            string unit = CropUnitPicker.SelectedItem?.ToString();
            DateTime harvestDate = HarvestDatePicker.Date;

            if (string.IsNullOrEmpty(cropName) || string.IsNullOrEmpty(quantity) || unit == null)
            {
                DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            // TODO: Save or submit the data
            DisplayAlert("Success", $"Crop '{cropName}' with {quantity} {unit} has been submitted.", "OK");
        }

        // Navigation Event Handlers
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
