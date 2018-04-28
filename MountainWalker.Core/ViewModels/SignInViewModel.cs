using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Plugin.SecureStorage;
using Acr.UserDialogs;

namespace MountainWalker.Core.ViewModels
{
    public class SignInViewModel : MvxViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IWebAPIService _webAPIService;
        private readonly IMvxNavigationService _navigationService;

        public SignInViewModel(IDialogService dialogService, IWebAPIService webAPIService, IMvxNavigationService navigationService)
        {
            _dialogService = dialogService;
            _webAPIService = webAPIService;
            _navigationService = navigationService;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public IMvxCommand SignInButton => new MvxCommand(CheckLogin);

        private async void CheckLogin()
        {

            //bool result = await CheckIfLogged();
            bool result = true;
            if(result)
            {
                await _navigationService.Navigate<MainViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Login i/lub hasło są nieprawidłowe!", "OK");
            }
            
        }

        public IMvxCommand RegisterButton => new MvxCommand(JumpRegister);

        private void JumpRegister()
        {
            _navigationService.Navigate<RegisterViewModel>();
        }

        private string _login;
        private string _password;
        private bool _isChecked;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaisePropertyChanged(() => IsChecked);
            }
        }

        public async Task<bool> CheckIfLogged()
        {

            UserDialogs.Instance.ShowLoading("Logowanie...");
            bool result = await _webAPIService.CheckIfUserCanLogin(_login, _password);

            if (result)
            {
                if (_isChecked == true)
                {
                    CrossSecureStorage.Current.SetValue("Session", _password);
                }
                UserDialogs.Instance.HideLoading();
                return true;
            }
            else
            {
                UserDialogs.Instance.HideLoading();
                return false;
            }
        }
    }
}
