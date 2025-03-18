using System.ComponentModel;
using Xamarin.Forms;
using XamlTester.ViewModels;

namespace XamlTester.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}