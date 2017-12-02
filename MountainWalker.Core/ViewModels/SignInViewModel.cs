using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class SignInViewModel : MvxViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly ISharedPreferencesService _sharedPreferencesService;

        public SignInViewModel(IDialogService dialogService, ISharedPreferencesService sharedPreferencesService)
        {
            _dialogService = dialogService;
            _sharedPreferencesService = sharedPreferencesService;

        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public IMvxCommand SignInButton => new MvxCommand(CheckFields);
        private void CheckFields()
        {
            if(_isChecked == true)
            {
                _sharedPreferencesService.SetSharedPreferences(_login,_password);
            }

            if (_login.Equals("admin") && _password.Equals("admin"))
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Dane są nieprawidłowe", "OK");
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
