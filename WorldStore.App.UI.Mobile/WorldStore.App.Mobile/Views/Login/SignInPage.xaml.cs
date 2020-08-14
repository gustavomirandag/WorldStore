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
            var result = App.AppService.SignIn(EntryUsername.Text, EntryPassword.Text);

            if (result == false)
            {
                DisplayAlert("Usuário ou senha inválida!", "Usuário ou senha inválida, digite novamente!", "Ok");
                return;
            }

            Navigation.InsertPageBefore(new MainPage(), this);
            Navigation.PopAsync().ConfigureAwait(false);
        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignUpPage());
        }
    }
}