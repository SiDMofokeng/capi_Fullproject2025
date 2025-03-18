using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Linq;
using Newtonsoft.Json;

namespace XamlTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkItemDetailPage : ContentPage
    {
        public WorkItem SelectedWorkItem { get; set; }
        public ObservableCollection<DwellingUnit> DwellingUnits { get; set; }
        public int StructureCount => DwellingUnits?.Count ?? 0;

        public WorkItemDetailPage(WorkItem selectedItem)
        {
            InitializeComponent();
            SelectedWorkItem = selectedItem;
            BindingContext = this;

            // ✅ Load stored structures
            LoadStructures();
        }

        // ✅ Load structures from local storage
        private void LoadStructures()
        {
            string storedData = Preferences.Get("DwellingUnits", null);
            if (!string.IsNullOrEmpty(storedData))
            {
                DwellingUnits = JsonConvert.DeserializeObject<ObservableCollection<DwellingUnit>>(storedData);
            }
            else
            {
                // Default structures if no saved data
                DwellingUnits = new ObservableCollection<DwellingUnit>
                {
                    new DwellingUnit { StructureNumber = "1", FeatureCategory = "Dwelling Unit", Features = "Brick Walls, Tiled Roof", Description = "Main House", Unpacked = "Yes" },
                    new DwellingUnit { StructureNumber = "2", FeatureCategory = "Dwelling Unit", Features = "Concrete Walls, Flat Roof", Description = "Backroom or rented structure", Unpacked = "No" },
                    new DwellingUnit { StructureNumber = "3", FeatureCategory = "Special Institution", Features = "Steel Walls, Concrete Roof", Description = "Other", Unpacked = "Yes" }
                };
            }

            DwellingUnitsListView.ItemsSource = DwellingUnits;
            UpdateStructureCount();
        }

        // ✅ Save structures when new ones are added
        private void SaveStructures()
        {
            string serializedData = JsonConvert.SerializeObject(DwellingUnits);
            Preferences.Set("DwellingUnits", serializedData);
        }

        private void UpdateStructureCount()
        {
            OnPropertyChanged(nameof(StructureCount));
        }

        private void OnBackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(); // Go back to MyWorkDashboard
        }

        private void OnEditClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Edit", "Editing the dwelling unit...", "OK");
        }

        private void OnContinueClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Continue", "Continuing with the dwelling unit...", "OK");
        }

        // ✅ "Update" Button Now Saves New Structures Permanently
        private async void OnUpdateClicked(object sender, System.EventArgs e)
        {
            string featureCategory = await DisplayActionSheet("Select Feature Category", "Cancel", null,
                "Dwelling Unit", "Homeless", "Special Institution", "Transient");
            if (featureCategory == "Cancel" || featureCategory == null) return;

            string features = await DisplayPromptAsync("Features", "Enter features (e.g., Brick Walls, Tiled Roof)");
            if (string.IsNullOrWhiteSpace(features)) return;

            string description = await DisplayActionSheet("Select Description", "Cancel", null,
                "Main House", "Backroom or rented structure", "Garage Used As Rental Structure", "Other");
            if (description == "Cancel" || description == null) return;

            string unpacked = await DisplayActionSheet("Is the structure unpacked?", "Cancel", null, "Yes", "No");
            if (unpacked == "Cancel" || unpacked == null) return;

            // ✅ Add new structure and save
            int newStructureNumber = DwellingUnits.Count + 1;
            DwellingUnits.Add(new DwellingUnit
            {
                StructureNumber = newStructureNumber.ToString(),
                FeatureCategory = featureCategory,
                Features = features,
                Description = description,
                Unpacked = unpacked
            });

            SaveStructures();  // ✅ Save to local storage
            UpdateStructureCount();

            await DisplayAlert("Success", "New structure added successfully.", "OK");
        }
    }

    public class DwellingUnit
    {
        public string StructureNumber { get; set; }
        public string FeatureCategory { get; set; }
        public string Features { get; set; }
        public string Description { get; set; }
        public string Unpacked { get; set; }
    }
}
