using System;
using Android.App;
using MountainWalker.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Services
{
    class DroidRegisterService : IRegisterService
    {
        public Boolean CheckData(string name, string surname, string login, string password, string repassword, string email)
        {
            if (name.Length < 2 || surname.Length < 2 || login.Length < 3 || password.Length == 6 || repassword.Length < 6|| email.Length < 3)
                return false;
            return true;
        }

        //public boolean createuser(string name, string surname, string login, string password, string repassword, string email)
        //{
        //    using (sqlconnection connection = new sqlconnection(connectionstring))
        //    {
        //        connection.open();
        //        // do work here; connection closed on following line.
        //    }
        //}
    }
}