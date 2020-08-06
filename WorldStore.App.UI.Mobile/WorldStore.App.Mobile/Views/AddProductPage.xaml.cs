using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Domain.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            var name = EntryName.Text;
            var photo = EntryPhoto.Text;
            Decimal price = 0;
            if (!Decimal.TryParse(EntryPrice.Text, out price))
            {
                await DisplayAlert("Invalid Price", "Please, type a valid price", "Ok");
                return;
            }
                
            var product = new Product
            {
                Name = name,
                PhotoUrl = photo,
                Price = price
            };

            await App.Service.AddProductAsync(product);
            await Navigation.PopModalAsync(true);
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}