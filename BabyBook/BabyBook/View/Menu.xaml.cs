using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabyBook.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());

			// Open the Baby Info Page
			Detail.Navigation.PushAsync(new InfoBabyPage());
			IsPresented = false;
		}

		private void GoInfoBabyPage(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new InfoBabyPage());
			IsPresented = false;
		}

		private void GoPage2(object sender, System.EventArgs e)
		{ 
		}
		private void GoPage3(object sender, System.EventArgs e)
		{

		}
	}
}