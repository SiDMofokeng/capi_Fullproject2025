using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTester
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HouseholdQuestionnairepAGE_Two_Pop_Up : ContentPage
	{
		public HouseholdQuestionnairepAGE_Two_Pop_Up ()
		{
			InitializeComponent ();
		}

        private async void OnAddNewClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewPopup());
        }


    }
}