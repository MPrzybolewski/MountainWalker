using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {

        public IMvxCommand LoginCommand => new MvxCommand(hehe); //tutaj chce zeby to dzialalo inaczej w androidzie i inaczej w iOS
        private void hehe()
        {
            if (DoLogin(_login, _password))
            {
                ShowViewModel<MainViewModel>();
                
            }
        }

        private string _login = "";
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        private string _password = "";

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private bool DoLogin(string login, string password)
        {
            Debug.WriteLine(login + " " + password);

            if (login.Equals("admin") && password.Equals("admin"))
            {
                return true;
            }
            return false;
        }




    }
}
