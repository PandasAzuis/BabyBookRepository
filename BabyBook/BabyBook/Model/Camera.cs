using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyBook.Model
{
    public static class Camera
    {
        public static async Task<MediaFile> GetPhoto()
        {
            try
            {
                //var status = await Plugin.Permissions.CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Camera);

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    throw new Exception("Galeria de fotos não suportada.");
                }

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return null;

                return file;

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
