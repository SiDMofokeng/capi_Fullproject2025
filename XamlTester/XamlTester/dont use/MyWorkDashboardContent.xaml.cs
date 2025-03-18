using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyWorkDashboardContent : ContentPage
    {

        ObservableCollection<WorkItem> WorkItems;
        ObservableCollection<WorkItem> FilteredWorkItems;

        public MyWorkDashboardContent()
        {
            InitializeComponent();

            // Sample data
            WorkItems = new ObservableCollection<WorkItem>
            {
                new WorkItem { Province = "Northern Cape", District = "John Tolo", MapReference = "98754093_09241", EANumber = "3868497200", DUCount = "1" },
                new WorkItem { Province = "Gauteng", District = "Frances Baard", MapReference = "98754093_75802", EANumber = "384200901", DUCount = "1" },
                new WorkItem { Province = "Eastern Cape", District = "Lungi Tolo", MapReference = "98754093_80123", EANumber = "3601102200", DUCount = "1" }
            };

            FilteredWorkItems = new ObservableCollection<WorkItem>(WorkItems);
            WorkListView.ItemsSource = FilteredWorkItems;
        }

        // ✅ Fix: Ensure the event handler exists
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue.ToLower();

            FilteredWorkItems.Clear();
            foreach (var item in WorkItems.Where(w => w.Province.ToLower().Contains(searchText) || w.District.ToLower().Contains(searchText)))
            {
                FilteredWorkItems.Add(item);
            }
        }

        private void OnBurgerMenuClicked(object sender, System.EventArgs e)
        {
            // Open the burger menu
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = true;
            }
        }

        // ✅ Handle user clicking an item
        private void OnWorkItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is WorkItem selectedItem)
            {
                Navigation.PushAsync(new WorkItemDetailPage(selectedItem)); // Navigates to Dwelling Units Page
            }

            WorkListView.SelectedItem = null;
        }

    }

    // Work Item Model
    public class WorkItem
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string MapReference { get; set; }
        public string EANumber { get; set; }
        public string DUCount { get; set; }
    }

}
