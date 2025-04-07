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
    public partial class AllCrops : ContentPage
    {
        public AllCrops()
        {
            InitializeComponent();
        }
    


    private  void OnCropClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string cropName)
            {
                Navigation.PushAsync(new InfoPage());
            }
        }

    } 
}