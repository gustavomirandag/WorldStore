using IdentityModel.Client;
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

        private static string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "http://localhost:5000/connect/token",

                ClientId = "PostmanClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }
    }
}
