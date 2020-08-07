using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {

        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}