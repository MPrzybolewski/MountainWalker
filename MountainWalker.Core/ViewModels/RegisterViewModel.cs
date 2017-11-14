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
        private string _name = "";
        private string _surname = "";
        private string _login = "";
        private string _password = "";
        private string _repPassword = "";
        private string _email = "";
        private readonly IDialogService _dialogService;
        private readonly IRegisterService _registerService;

        public RegisterViewModel(IDialogService dialogService, IRegisterService registerService)
        {
            _dialogService = dialogService;
            _registerService = registerService;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
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
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public IMvxCommand RegisterButton => new MvxCommand(Walidate);
        private void Walidate()
        {
            if (_registerService.CheckData(_name,_surname,_login,_password,_repPassword,_email))
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Dane są nieprawidłowe", "OK");
            }
        }
    }
}
