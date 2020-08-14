using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldStoreApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void ButtonSignIn_Clicked(object sender, EventArgs e)
        {
            var token = GetToken(EntryUsername.Text, EntryPassword.Text);
            if (String.IsNullOrEmpty(token))
            {
                DisplayAlert("Usuário ou senha inválida!", "Usuário ou senha inválida, digite novamente!", "Ok");
                return;
            }

            App.Token = token;

            Navigation.InsertPageBefore(new MainPage(), this);
            Navigation.PopAsync().ConfigureAwait(false);
        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignUpPage());
        }

        private string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://worldstore-gustavo-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "Postman_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }
    }
}