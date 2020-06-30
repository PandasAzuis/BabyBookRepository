using BabyBook.Model;
using BabyBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabyBook.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoBabyPage : ContentPage
    {
        public BabyInfoViewModel BabyInfoViewModel { get; set; }
        public InfoBabyPage()
        {
            InitializeComponent();
            this.BabyInfoViewModel = new BabyInfoViewModel();
            LoadBaby();
        }

        private async void LoadBaby()
        {
            try
            {
                Baby baby = await this.BabyInfoViewModel.GetBaby();

                if (baby == null)
                    return;

                this.nameEntry.Text = baby.Name;
                if(!string.IsNullOrEmpty(baby.BirthDate))
                this.birthDatePicker.Date = Convert.ToDateTime(baby.BirthDate);
                if(!string.IsNullOrEmpty(baby.BirthTime))
                this.birthTimePicker.Time = TimeSpan.Parse(baby.BirthTime);
                this.weightEntry.Text = baby.Weight;
                this.heightEntry.Text = baby.Height;
                this.maternityHospitalEntry.Text = baby.MaternityHospital;
                this.bloodTypePCK.SelectedItem = baby.BloodType;
            }
            catch (Exception exp)
            {
                await DisplayAlert("Ops", exp.Message, "OK");
            }
        }

        private  void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {

                var baby = new Baby
                {
                    Name = nameEntry.Text,
                    BirthDate = birthDatePicker.Date.ToString(),
                    BirthTime = birthTimePicker.Time.ToString(),
                    Weight = weightEntry.Text,
                    Height = heightEntry.Text,
                    MaternityHospital = maternityHospitalEntry.Text,
                    BloodType = bloodTypePCK.Items[bloodTypePCK.SelectedIndex]
                };

                BabyInfoViewModel.SetBaby(baby);
            }
            catch (Exception exp)
            {
                 DisplayAlert("Ops", exp.Message, "OK");
            }
        }
    }
}