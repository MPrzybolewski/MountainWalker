using Newtonsoft.Json;
using System;
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

        public async Task<string[]> CheckIfUserCanRegister(string _name, string _surname, string _login, string _password, string _email)
        {
            string[] parts = new string[6];
            var clientt = new HttpClient();
            clientt.BaseAddress = new Uri(_url);
            object userInfos = new { UserID = "2", name = _name, surname = _surname, login = _login, password = _password, email = _email };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await clientt.PostAsync("/api/users/postuser", content);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                parts = result.Split(',');
                parts[0] = parts[0].Substring(1);
                parts[5] = parts[5].Trim(']');
                if (parts[0].Equals("true"))
                {
                    return parts;
                }
                return parts;
            } catch (Exception)
            {
                return parts;
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
    }
}
