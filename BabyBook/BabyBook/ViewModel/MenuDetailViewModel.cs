using BabyBook.Model;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BabyBook.ViewModel
{
    public class MenuDetailViewModel
    {
        public async Task<MediaFile> SavePhoto()
        {
            try
            {
                byte[] file;
                var taskFile = await Camera.GetPhoto();
                var stream = taskFile.GetStream();

                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    file = memoryStream.ToArray();
                }

                var baby = new Baby
                {
                    ID = 0,
                    FistPhoto = file
                };

                await App.Database.SaveBaby(baby);

                return taskFile;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ImageSource> GetBabyPhoto()
        {
            try
            {

                var baby = await App.Database.GetBabys();
                
                if (baby.Count <= 0)
                    return null;

                Stream stream = new MemoryStream(baby[0].FistPhoto);

                return ImageSource.FromStream(() => { return stream; }); ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
