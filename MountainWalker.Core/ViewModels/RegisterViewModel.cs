using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Acr.UserDialogs;
using System.Diagnostics;

namespace MountainWalker.Core.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private string _name = "";
        private string _namePlaceholder = "Imię";
        private string _surname = "";
        private string _surnamePlaceholder = "Nazwisko";
        private string _login = "";
        private string _loginPlaceholder = "Login";
        private string _password = "";
        private string _passwordPlaceholder = "Hasło";
        private string _repPassword = "";
        private string _email = "";
        private string _emailPlaceholder = "Email";
        private readonly IDialogService _dialogService;
        private readonly IWebAPIService _webAPIService;
        private readonly IMvxNavigationService _navigationService;

        public RegisterViewModel(IDialogService dialogService, IWebAPIService webAPIService, IMvxNavigationService navigationService)
        {
            _dialogService = dialogService;
            _webAPIService = webAPIService;
            _navigationService = navigationService;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
        public string NamePlaceholder
        {
            get { return _namePlaceholder; }
            set
            {
                _namePlaceholder = value;
                RaisePropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                RaisePropertyChanged();
            }
        }
        public string SurnamePlaceholder
        {
            get => _surnamePlaceholder;
            set
            {
                _surnamePlaceholder = value;
                RaisePropertyChanged();
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                RaisePropertyChanged();
            }
        }
        public string LoginPlaceholder
        {
            get => _loginPlaceholder;
            set
            {
                _loginPlaceholder = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }
        public string PasswordPlaceholder
        {
            get => _passwordPlaceholder;
            set
            {
                _passwordPlaceholder = value;
                RaisePropertyChanged();
            }
        }
        public string RepPassword
        {
            get { return _repPassword; }
            set
            {
                _repPassword = value;
                RaisePropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }
        public string EmailPlaceholder
        {
            get => _emailPlaceholder;
            set
            {
                _emailPlaceholder = value;
                RaisePropertyChanged();
            }
        }

        public IMvxCommand RegisterButton => new MvxCommand(Validate);
        private async void Validate()
        {
            if (_password.Equals(_repPassword))
            {
                bool result = await CheckIfRegistered(_name, _surname, _login, _password, _email);
                if (result)
                {
                    _navigationService.Navigate<SignInViewModel>();
                }
                else
                {
                    _dialogService.ShowAlert("Uwaga!", "Błędne dane. Nie można zarejestrować!", "OK");
                }
            }
            else
            {
                Password = "";
                RepPassword = "";
                PasswordPlaceholder = "Hasło muszą być takie same!";
                _dialogService.ShowAlert("Uwaga!", "Błędne dane. Nie można zarejestrować!", "OK");
            }
        }

        public async Task<bool> CheckIfRegistered(string name, string surname, string login, string password, string email)
        {
            UserDialogs.Instance.ShowLoading("Rejestrowanie...");          
            string[] result = await _webAPIService.CheckIfUserCanRegister(name, surname, login, password, email);
            if (result[0].Equals("true"))
            {
                UserDialogs.Instance.HideLoading();
                return true;
            }
            else
            {
                if(result[1].Equals("false"))
                {
                    Name = "";
                    NamePlaceholder = "Imię min. 2 znaków";
                }
                if (result[2].Equals("false"))
                {
                    Surname = "";
                    SurnamePlaceholder = "Nazwisko min. 2 znaków";
                }
                if (result[3].Equals("false"))
                {
                    Login = "";
                    LoginPlaceholder = "Login min. 3 znaków";
                }
                if (result[4].Equals("false"))
                {
                    Password = "";
                    RepPassword = "";
                    PasswordPlaceholder = "Hasło min. 6 znaków";
                }
                if (result[5].Equals("false"))
                {
                    Email = "";
                    EmailPlaceholder = "Błędny adres email";
                }
                UserDialogs.Instance.HideLoading();
                return false;
            }
        }
    }
}
