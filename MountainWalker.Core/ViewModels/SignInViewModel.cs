using System;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MountainWalker.Core.ViewModels
{
    public class SignInViewModel : MvxViewModel
    {
        private readonly IDialogService _dialogService;

        public SignInViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public IMvxCommand SignInButton => new MvxCommand(CheckFields);
        private void CheckFields()
        {
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
    }


}
