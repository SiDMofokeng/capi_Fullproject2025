using System;
using Xamarin.Forms;

namespace XamlTester
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            // Set MyWorkDashboard as the main page (Since it's a FlyoutPage)
            Application.Current.MainPage = new MyWorkDashboard();
        }

    }
}
