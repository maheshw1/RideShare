using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RideShare.ViewModel
{
    public class ProfileMenuViewModel : INotifyPropertyChanged
    {
        private ProfileMenuViewModel() { }
        public ProfileMenuViewModel(INavigation navigation)
        {
            EditProfileImageSource = ImageSource.FromResource("RideShare.Images.navigation.edit.png");
            HistoryImageSource = ImageSource.FromResource("RideShare.Images.navigation.history.png");
            SettingsImageSource = ImageSource.FromResource("RideShare.Images.navigation.settings.png");
            HelpImageSource = ImageSource.FromResource("RideShare.Images.navigation.help.png");
            AboutImageSource = ImageSource.FromResource("RideShare.Images.navigation.about.png");
            LogoutImageSource = ImageSource.FromResource("RideShare.Images.navigation.logout.png");
        }
         
        public ImageSource EditProfileImageSource { protected set; get; }
        public ImageSource HistoryImageSource { protected set; get; } 
        public ImageSource SettingsImageSource { protected set; get; }
        public ImageSource HelpImageSource { protected set; get; }
        public ImageSource AboutImageSource { protected set; get; }
        public ImageSource LogoutImageSource { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
