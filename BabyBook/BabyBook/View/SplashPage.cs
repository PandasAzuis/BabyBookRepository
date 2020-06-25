using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BabyBook.View
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();

            // Image to be loaded
            splashImage = new Image
            {
                Source = "BabyShadowGray.png",
                WidthRequest = 350,
                HeightRequest = 350
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#FFB6C1");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Animation effect
            await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(0.8, 1400, Easing.Linear);
            await splashImage.ScaleTo(140, 1100, Easing.Linear);

            Application.Current.MainPage = new MainPage();
        }

    }
}
