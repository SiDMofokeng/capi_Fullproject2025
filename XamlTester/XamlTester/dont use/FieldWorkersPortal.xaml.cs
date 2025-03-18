using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldWorkersPortal : ContentPage
    {
        public FieldWorkersPortal()
        {
            InitializeComponent();
        }

        private void OnBackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(); // ✅ Go back to MyWorkDashboard
        }

        private void OnTabClicked(object sender, System.EventArgs e)
        {
            string tab = (sender as Button).CommandParameter.ToString();

            // Hide all tab content first
            InterviewsContent.IsVisible = false;
            DashboardContent.IsVisible = false;
            ReturnsContent.IsVisible = false;
            MyWorkSignOffContent.IsVisible = false;

            // Show selected tab
            switch (tab)
            {
                case "Interviews":
                    InterviewsContent.IsVisible = true;
                    break;
                case "Dashboard":
                    DashboardContent.IsVisible = true;
                    break;
                case "Returns":
                    ReturnsContent.IsVisible = true;
                    break;
                case "MyWorkSignOff":
                    MyWorkSignOffContent.IsVisible = true;
                    break;
            }
        }

        private void OnUpdateClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Update", "Updating interviews...", "OK");
        }
    }
}
