using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Application.Models.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WorldStore.App.Application.Models.Dtos.UserPasswordDto;

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

            var result = App.AppService.SignUp(userPasswordDto);

            if (result == false)
            {
                DisplayAlert("Não foi possível criar o usuário!", "Erro ao tentar criar o usuário!" , "Ok");
                return;
            }

            DisplayAlert("Usuário Criado", "Usuário criado com sucesso!", "Ok");

            Navigation.PopModalAsync();
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

    }
}