using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyWorkDashboard : FlyoutPage
    {
        public MyWorkDashboard()
        {
            InitializeComponent();
        }

        private async void GoToFieldWorkersPortal(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FieldWorkersPortal());
        }

        private async void GoToHouseholdQuestionnaire(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HouseholdQuestionnaire());
        }

        private async void GoToResultsCodeScreen(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ResultsCodeScreen());
        }

        private void GoToHelp(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new HelpPage()); // Navigate inside MyWorkDashboard
            IsPresented = false; // Close menu
        }

        private void GoToSettings(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new SettingsPage()); // Navigate inside MyWorkDashboard
            IsPresented = false;
        }

        private void OnLogout(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage()); // Reset to login
        }
    }
}
