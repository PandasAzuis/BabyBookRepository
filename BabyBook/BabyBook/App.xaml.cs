using BabyBook.Model;
using BabyBook.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabyBook
{
    public partial class App : Application
    {
        static Database database { get; set; }

        public static Database Database
        {
            get
            {
                if(database == null)
                {
                   database = new Database(Path.Combine
                       (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                       "babybookdb.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
