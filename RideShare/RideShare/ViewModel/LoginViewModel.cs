using RideShare.View;
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
    public class LoginViewModel : INotifyPropertyChanged
    {
    
        private string userName;
        private string password;
        private INavigation navigation;

        private enum UserAction
        {
            User_Login,
            Driver_Login
        }

        private string userAction;

        private LoginViewModel()
        { 
        }

        public LoginViewModel(INavigation navigation) 
        {
            LoginCommand = new Command(() => ExecuteLogin());
            RegisterCommand = new Command(() => ExecuteRegister());
            UserActiveCommand = new Command<string>(ExecuteUserActive);
            DriverActiveCommand = new Command<string>(ExecuteDriverActive);
            this.navigation = navigation;
            LogoImageSource = ImageSource.FromResource("RideShare.Images.login.loginlogo.png");
            UserLogImageSource = ImageSource.FromResource("RideShare.Images.login.userLogActive_icon.png");
            DriverLogImageSource = ImageSource.FromResource("RideShare.Images.login.driverLog_icon.png");
        }

        // Public properties
        public string UsernameText
        {
            get { return userName; }
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
            get { return password; }
            set
            {
                if (password == value)
                    return;
                password = value;
                OnPropertyChanged("PasswordText");
            }
        }

       
        // ICommand implementations
        public ICommand LoginCommand {protected set; get; }

        public ICommand RegisterCommand { protected set; get; }

        public ICommand UserActiveCommand { protected set; get; }
         
        public ICommand DriverActiveCommand { protected set; get; }

        public ImageSource DriverLogImageSource { protected set; get; }

        public ImageSource UserLogImageSource { protected set; get; }

        public ImageSource LogoImageSource { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void ExecuteLogin()
        {
            //string xx = string.Empty;
            //xx = this.UsernameText;
            MasterDetailPage profilePage = new ProfileMasterPage();
            await navigation.PushAsync(profilePage);

        }

        private async void ExecuteRegister()
        {
            NavigationPage registerPage = new NavigationPage(new RegisterPage());
            await navigation.PushAsync(registerPage);
        }

        private void ExecuteUserActive(string action)
        {
            userAction = action;
            UserLogImageSource = ImageSource.FromResource("RideShare.Images.login.userLogActive_icon.png");
            OnPropertyChanged("UserLogImageSource");
            ExecuteUserInactive("DriverLogImageSource");
        }

        private void ExecuteDriverActive(string action)
        {
            userAction = action;
            DriverLogImageSource = ImageSource.FromResource("RideShare.Images.login.driverLogActive_icon.png");
            OnPropertyChanged("DriverLogImageSource");
            ExecuteUserInactive("UserLogImageSource");
        }

        //private void ExecuteUserActive(string action, string propertyName)
        //{
        //    if (action == "User_Login")
        //    {
        //        UserLogImageSource = ImageSource.FromResource("RideShare.Images.login.userLogActive_icon.png");
        //        ExecuteUserInactive(action, "DriverLogImageSource");
        //    }
        //    else if (action == "Driver_Login")
        //    {
        //        DriverLogImageSource = ImageSource.FromResource("RideShare.Images.login.driverLogActive_icon.png");
        //        ExecuteUserInactive(action, "UserLogImageSource");
        //    }

        //    OnPropertyChanged(propertyName);
        //}

        private void ExecuteUserInactive(string propertyName)
        {
            if (userAction == UserAction.User_Login.ToString())
            {
                DriverLogImageSource = ImageSource.FromResource("RideShare.Images.login.driverLog_icon.png");
            }
            else if (userAction == UserAction.Driver_Login.ToString())
            {
                UserLogImageSource = ImageSource.FromResource("RideShare.Images.login.userLog_icon.png");
            }

            OnPropertyChanged(propertyName);
        }

    }
}
