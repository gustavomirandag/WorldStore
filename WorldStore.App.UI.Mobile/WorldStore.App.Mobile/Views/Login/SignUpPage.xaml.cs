using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldStoreApp.Views.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldStoreApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void  ButtonRegister_Clicked(object sender, EventArgs e)
        {
            var token = GetAdminToken();
            if (String.IsNullOrEmpty(token))
            {
                DisplayAlert("Usuário ou senha inválida!", "Usuário ou senha inválida, digite novamente!", "Ok");
                return;
            }

            var userPasswordDto = new UserPasswordDto
            {
                user = new User
                {
                    email = EntryEmail.Text,
                    userName = EntryUsername.Text,
                    phoneNumber = EntryPhone.Text,
                    emailConfirmed = true,
                    lockoutEnabled = true,
                    phoneNumberConfirmed = true
                },
                password = new Password
                {
                    password = EntryPassword.Text,
                    confirmPassword = EntryPassword.Text
                }
            };

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var serializedUserPassword = JsonConvert.SerializeObject(userPasswordDto);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://worldstore-gustavo-iammicroservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;



            if (!result.IsSuccessStatusCode)
            {
                var message = result.Content.ReadAsStringAsync().Result;
                DisplayAlert("Não foi possível criar o usuário!", message, "Ok");
                return;
            }

            DisplayAlert("Usuário Criado", "Usuário criado com sucesso!", "Ok");

            Navigation.PopModalAsync();
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://worldstore-gustavo-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "Postman_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = "admin",
                Password = "@dsInf123"
            }).Result;

            return response.AccessToken;
        }
    }
}