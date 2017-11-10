using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MountainWalker.Core.ViewModels
{
    class RegisterViewModel : MvxViewModel
    {
        private string _login = "";
        private string _password = "";
        private string _repPassword = "";
        private readonly IDialogService _dialogService;

        public RegisterViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
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
        public string RepPassword
        {
            get { return _repPassword; }
            set { _repPassword = value; }
        }

        public IMvxCommand RegisterButton => new MvxCommand(CheckFields);
        private void CheckFields()
        {
            if (_login.Equals("admin") && _password.Equals(_repPassword))
            {
                ShowViewModel<SignInViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Dane są nieprawidłowe", "OK");
            }
        }
    }
}
