using MountainWalker.Core.Models;
using Newtonsoft.Json;
using Plugin.SecureStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MountainWalker.Core.Interfaces.Impl
{
    class WebAPIService : IWebAPIService
    {
        HttpClient client;
        private IDialogService _dialog;
        private string _url = "http://mountainwalkerwebapi.azurewebsites.net";

        public WebAPIService(IDialogService dialogService)
        {
            _dialog = dialogService;
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<bool> CheckIfUserCanRegister(string _name, string _surname, string _login, string _password, string _email)
        {

            var clientt = new HttpClient();
            clientt.BaseAddress = new Uri(_url);
            object userInfos = new { UserID = "2", name = _name, surname = _surname, login = _login, password = _password, email = _email };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            Debug.WriteLine("BEkaaaaaa " + jsonObj);
            StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await clientt.PostAsync("/api/users/postuser", content);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                if (result.Equals("true"))
                {
                    return true;
                }

                return false;
            } catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> CheckIfUserCanLogin(string _login, string _password)
        {
            var clientt = new HttpClient();
            clientt.BaseAddress = new Uri(_url);
            object userInfos = new { UserID = "2", name = "name", surname = "surname", login = _login, password = _password, email = "email" };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await clientt.PostAsync("/api/Users/CheckLogin", content);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                if (result.Equals("true"))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> GetName(string _login)
        {
            var clientt = new HttpClient();
            clientt.BaseAddress = new Uri(_url);
            object userInfos = new { UserID = "", name = "", surname = "", login = _login, password = "", email = "" };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            var response = await clientt.PostAsync("/api/Users/GetName", content);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                {
                    return result.Trim('"');
                }

                return "err";
            }
            catch (Exception)
            {
                return "err";
            }
        }

        public async Task<List<ReachedTrail>> GetReachedTrailsList(string login)
        {
            //all magic with dbconn
            int id = 0;
            var items = new List<ReachedTrail>()
            {
                new ReachedTrail(id++, "10.04.2010", "Ygrek", "Ug", ParePointsFromDb(id)),
                new ReachedTrail(id++, "11.04.2010", "Skm", "Ug", ParePointsFromDb(id)),
                new ReachedTrail(id++, "12.04.2010", "Ygrek", "KFC", ParePointsFromDb(id))
            };

            return items;
        }

        public async Task GetReachedAchievements(string _login)
        {
            //magic
            var clientt = new HttpClient();
            clientt.BaseAddress = new Uri(_url);
            object userInfos = new { UserID = "", name = "", surname = "", login = _login, password = "", email = "" };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            var response = await clientt.PostAsync("/api/Users/GetAchievementsForGivenUser", content);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                CrossSecureStorage.Current.SetValue(CrossSecureStorageKeys.Achievements, result);
                if (result != null)
                {
                    // ?
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("err");
            }
        }

        private List<Point> ParePointsFromDb(int id)
        {
            return new List<Point>
            {
                new Point(54.400647, 18.576544),
                new Point(54.400528, 18.576064),
                new Point(54.400712, 18.575901),
                new Point(54.400772, 18.575757),
                new Point(54.400763, 18.575352),
                new Point(54.401061, 18.575101),
                new Point(54.400818, 18.574548),
                new Point(54.400810, 18.574563),
                new Point(54.399849, 18.575161),
                new Point(54.399249, 18.575701),
                new Point(54.397705, 18.577010),
                new Point(54.397800, 18.576788),
                new Point(54.397216, 18.575113),
                new Point(54.396893, 18.575427),
                new Point(54.396567, 18.574493),
                new Point(54.396324, 18.573653),
                new Point(54.396269, 18.573682),
                new Point(54.396157, 18.573419),
                new Point(54.396110, 18.573478)
            };
        }
    }         
}             
