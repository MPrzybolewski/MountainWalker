using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainWalker.Core.Interfaces
{
    public interface IWebAPIService
    {
        Task<bool> CheckIfUserCanRegister(string name, string surname, string login, string password, string email);
        Task<bool> CheckIfUserCanLogin(string _login, string _password);
        bool CheckLength(string name, string surname, string login, string password, string email);
    }
}
