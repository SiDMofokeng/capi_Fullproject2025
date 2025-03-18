using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsCodeScreen : ContentPage
    {
        public ResultsCodeScreen()
        {
            InitializeComponent();
        }

        private void OnBackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(); // ✅ Go back to MyWorkDashboard
        }
    }
}
