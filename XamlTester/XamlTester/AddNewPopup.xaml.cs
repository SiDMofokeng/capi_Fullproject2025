using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    public partial class AddNewPopup : ContentPage
    {
        public AddNewPopup()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            string firstInput = firstInputEntry.Text;
            string secondInput = secondInputEntry.Text;

            if (!string.IsNullOrEmpty(firstInput) && !string.IsNullOrEmpty(secondInput))
            {
                await DisplayAlert("Success", $"New entry added:\nField 1: {firstInput}\nField 2: {secondInput}", "OK");
                await Navigation.PopModalAsync(); // Close the popup
            }
            else
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(); // Close the popup without saving
        }
    }
}
