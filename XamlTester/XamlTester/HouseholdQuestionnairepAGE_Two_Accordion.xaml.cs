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
	public partial class HouseholdQuestionnairepAGE_Two_Accordion : ContentPage
	{
		public HouseholdQuestionnairepAGE_Two_Accordion ()
		{
			InitializeComponent ();
		}

        private void OnCoverPageClicked(object sender, EventArgs e)
        {
            coverPageContent.IsVisible = !coverPageContent.IsVisible;
        }

    }
}