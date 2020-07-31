using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace WorldStore.App.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://localhost:54891
            System.Console.WriteLine(GetToken("Pivotto","@dsInf123"));
        }

        private class LoginDto
        {
            public string grant_type { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string client_id { get; set; }
            public string clientid { get; set; }
        }

        private class Token
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string userName { get; set; }
            [JsonProperty(".issued")]
            public string issued { get; set; }
            [JsonProperty(".expires")]
            public string expires { get; set; }
        }

        private static string GetToken(string username, string password)
        {
            var httpClient = new HttpClient();
            var loginDto = new LoginDto
            {
                grant_type = "Password",
                username = username,
                password = password,
                client_id = "PostmanClientId",
                clientid = "PostmanClientId"
            };

            var serializedLoginDto = JsonConvert.SerializeObject(loginDto);
            var httpContent = new StringContent(serializedLoginDto, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("http://localhost:5000/connect/token", httpContent).Result;
            var token = result.Content.ReadAsStringAsync().Result;
            return token;
        }
    }
}
