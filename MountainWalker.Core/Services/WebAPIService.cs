using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MountainWalker.Core.Interfaces.Impl
{
    class WebAPIService : IWebAPIService
    {
        HttpClient client;
        private IDialogService _dialog;

        public WebAPIService(IDialogService dialogService)
        {
            _dialog = dialogService;
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<string> CheckIfUserCanRegister(string RestUrl, string _name, string _surname, string _login, string _password, string _email)
        {
            var clientt = new HttpClient();
            clientt.BaseAddress = new Uri(RestUrl);
            object userInfos = new { id = "2", name = _name, surname = _surname, login = _login, password = _password, email = _email };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await clientt.PostAsync("/api/users", content);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            } catch (Exception)
            {
                return "";
            }

        }

        public async Task<string> CheckIfUserCanLogin(string RestUrl)
        {
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            return "false";
        }
    }
}
