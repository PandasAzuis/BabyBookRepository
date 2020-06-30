using BabyBook.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyBook.ViewModel
{
    public class BabyInfoViewModel
    {
        public async Task<Baby> GetBaby()
        {
            try
            {
                if (Baby.Instance != null)
                    return Baby.Instance;

                var baby = await App.Database.GetBabys();

                if (baby.Count <= 0)
                    return null;

                Baby.Instance = baby[0];
                return Baby.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void SetBaby(Baby baby)
        {
            try
            {
                if(Baby.Instance == null)
                {
                    Baby.Instance = baby;
                    await App.Database.SaveBaby(Baby.Instance);
                }
                else
                {
                    baby.FistPhoto = Baby.Instance.FistPhoto;
                    Baby.Instance = baby;
                    await App.Database.UpdateBaby(Baby.Instance);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
