using BabyBook.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class MenuDetail : ContentPage
    {
        public MenuDetailViewModel MenuDetailViewModel { get; set; }
        public MenuDetail()
        {
            InitializeComponent();
            MenuDetailViewModel = new MenuDetailViewModel();
            LoadPhoto();
        }

        private async void LoadPhoto()
        {
            try
            {
                var photo = await this.MenuDetailViewModel.GetBabyPhoto();
                if(photo != null)
                BabyPhoto.Source = photo;
            }
            catch (Exception exp)
            {
                await DisplayAlert("Ops", exp.Message, "OK");
            }
        }

        private async void GetPhoto(object sender, EventArgs e)
        {
            try
            {
                var file = await this.MenuDetailViewModel.SavePhoto();

                BabyPhoto.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;

                });
            }
            catch (Exception exp)
            {
                await DisplayAlert("Ops",exp.Message,"OK");
            }
        }
    }
}
