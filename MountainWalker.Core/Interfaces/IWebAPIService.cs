using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainWalker.Core.Interfaces
{
    public interface IWebAPIService
    {
        Task<string> CheckIfUserCanLogin(string RestUrl);
    }
}
