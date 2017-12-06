using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class SignInViewModel : MvxViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly ISharedPreferencesService _sharedPreferencesService;
        private readonly IWebAPIService _webAPIService;

        public SignInViewModel(IDialogService dialogService, ISharedPreferencesService sharedPreferencesService,
            IWebAPIService webAPIService)
        {
            _dialogService = dialogService;
            _sharedPreferencesService = sharedPreferencesService;
            _webAPIService = webAPIService;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public IMvxCommand SignInButton => new MvxCommand(CheckLogin);

        private async void CheckLogin()
        {
            string RestUrl = "http://mountainwalkerwebapi.azurewebsites.net/api/users/" + _login + "?password=" +
                             _password;
            string result = await _webAPIService.CheckIfUserCanLogin(RestUrl);

            if (result.Trim(new char[] {'"'}).Equals("true"))
            {
                if (_isChecked == true)
                {
                    _sharedPreferencesService.SetSharedPreferences(_login, _password);
                }
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Login i/lub hasło są nieprawidłowe!", "OK");
            }
        }

        public IMvxCommand RegisterButton => new MvxCommand(JumpRegister);

        private void JumpRegister()
        {
            ShowViewModel<RegisterViewModel>();
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
                // RaisePropertyChanged(() => IsChecked);
            }
        }
    }
}
