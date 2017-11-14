using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainWalker.Core.Interfaces
{
    public interface IRegisterService
    {
        Boolean CheckData(string name, string surname, string login, string password, string repassword, string email);
    }
}
