using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnMyWorkTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MyWorkDashboard());
        }

        private void OnDashboardTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DashboardPage());
        }

        private void OnWorkSignOffTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new WorkSignOffPage());
        }
    }
}
