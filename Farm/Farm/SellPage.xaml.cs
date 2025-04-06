using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Farm
{
    public partial class SellPage : ContentPage
    {
        public SellPage()
        {
            InitializeComponent();
            _ = LoadTickets(); // Fire and forget
        }
        private async Task LoadTickets()
        {
            var tickets = await DatabaseHelper.Database.Table<CropSale>().ToListAsync();

            // Add a display-friendly string to each ticket
            foreach (var ticket in tickets)
            {
                ticket.QuantityDisplay = $"{ticket.Quantity} {ticket.Unit} harvested on {ticket.HarvestDate.ToShortDateString()}";
            }

            TicketsListView.ItemsSource = tickets;
        }

        // Submit Button Clicked
        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            string cropName = CropNameEntry.Text;
            string quantity = CropQuantityEntry.Text;
            string unit = CropUnitPicker.SelectedItem?.ToString();
            DateTime harvestDate = HarvestDatePicker.Date;

            if (string.IsNullOrEmpty(cropName) || string.IsNullOrEmpty(quantity) || unit == null)
            {
                await DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            if (_currentlyEditing != null)
            {
                _currentlyEditing.CropName = cropName;
                _currentlyEditing.Quantity = quantity;
                _currentlyEditing.Unit = unit;
                _currentlyEditing.HarvestDate = harvestDate;

                await DatabaseHelper.Database.UpdateAsync(_currentlyEditing);
                _currentlyEditing = null;
                await DisplayAlert("Updated", "Crop ticket updated successfully.", "OK");
            }
            else
            {
                var cropSale = new CropSale
                {
                    CropName = cropName,
                    Quantity = quantity,
                    Unit = unit,
                    HarvestDate = harvestDate
                };

                await DatabaseHelper.Database.InsertAsync(cropSale);
                await DisplayAlert("Success", $"Crop '{cropName}' submitted.", "OK");
            }

            // Clear form
            CropNameEntry.Text = "";
            CropQuantityEntry.Text = "";
            CropUnitPicker.SelectedIndex = -1;

            await LoadTickets();
        }

        
        private void TicketsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (TicketsListView.SelectedItem != null)
                TicketsListView.SelectedItem = null;
        }

        private CropSale _currentlyEditing = null;
        private void OnEditClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var item = (CropSale)menuItem.CommandParameter;

            // Pre-fill form
            CropNameEntry.Text = item.CropName;
            CropQuantityEntry.Text = item.Quantity;
            CropUnitPicker.SelectedItem = item.Unit;
            HarvestDatePicker.Date = item.HarvestDate;

            _currentlyEditing = item;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var item = (CropSale)menuItem.CommandParameter;

            bool confirm = await DisplayAlert("Delete", $"Are you sure you want to delete '{item.CropName}'?", "Yes", "No");
            if (confirm)
            {
                await DatabaseHelper.Database.DeleteAsync(item);
                await LoadTickets();
            }
        }

        private void TicketsListView_ItemTapped(object sender, EventArgs e)
        {
            // Optional: use this to debug or log selection
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
