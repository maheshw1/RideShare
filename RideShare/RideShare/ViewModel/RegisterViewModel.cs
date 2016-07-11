using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RideShare.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string lastName;
        private string firstName; 
        private string userName;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource AddPicImageSource { protected set; get; }

        public RegisterViewModel()
        {
            ProfileCreateCommand = new Command(() => ExecuteNewProfile());
            AddPicImageSource = ImageSource.FromResource("RideShare.Images.register.add_picture.png");
        }

        public string FirstNameText
        {
            get {return firstName; }

            set
            {
                if (firstName == value)
                    return;
                firstName = value;
                OnPropertyChanged("FirstNameText");
            }
            
        }
        public string LastNameText
        {
            get { return lastName; }
            set
            {
                if (lastName == value)
                    return;
                lastName = value;
                OnPropertyChanged("LastNameText");
            }
        }
        public string UsernameText
        {
            get {return userName; }
            set
            {
                if (userName == value)
                    return;
                userName = value;
                OnPropertyChanged("UsernameText");
            }
        }
        public string PasswordText
        {
            get {return password; }
            set
            {
                if (password == value)
                    return;
                password = value;
                OnPropertyChanged("PasswordText");
            }
        }

        // ICommand implementations
        public ICommand ProfileCreateCommand { protected set; get; }

        private void ExecuteNewProfile()
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
