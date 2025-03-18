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
	public partial class MyWorkPage : ContentPage
	{
		public MyWorkPage ()
		{
			InitializeComponent ();
		}
	}
}