using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface IWebAPIService
    {
        Task<string[]> CheckIfUserCanRegister(string name, string surname, string login, string password, string email);
        Task<bool> CheckIfUserCanLogin(string _login, string _password);
        Task GetReachedTrailsList(string login);
        Task GetReachedAchievements(string login);
        Task<string> GetName(string login);
        Task SaveTrail(ReachedTrail trail, string login);
        Task SaveAchievement(int id, string login, string date);
    }
}
