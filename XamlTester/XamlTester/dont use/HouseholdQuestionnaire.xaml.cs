using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseholdQuestionnaire : ContentPage
    {
        public HouseholdQuestionnaire()
        {
            InitializeComponent();
        }

        private void OnBackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(); // ✅ Go back to MyWorkDashboard
        }

        private async void OnSaveClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Saved", "Household details have been saved.", "OK");
        }

        private async void OnStartInterviewClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Interview", "Starting interview process...", "OK");
        }

        private void OnTabClicked(object sender, System.EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.CommandParameter.ToString() == "HouseholdInfo")
            {
                HouseholdInfoContent.IsVisible = true;
                MemberInfoContent.IsVisible = false;
            }
            else if (clickedButton.CommandParameter.ToString() == "MemberInfo")
            {
                HouseholdInfoContent.IsVisible = false;
                MemberInfoContent.IsVisible = true;
            }
        }
    }
}
