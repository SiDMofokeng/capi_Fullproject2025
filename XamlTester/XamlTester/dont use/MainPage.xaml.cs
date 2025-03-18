using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToHome(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false; // Close menu after selection
        }

        private void GoToMyWork(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new MyWorkDashboard());
            IsPresented = false;
        }

        private void GoToDashboard(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new DashboardPage());
            IsPresented = false;
        }

        private void OnSignOut(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
