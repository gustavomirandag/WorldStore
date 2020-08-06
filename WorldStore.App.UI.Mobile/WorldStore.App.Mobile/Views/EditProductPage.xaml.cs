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
    public partial class EditProductPage : ContentPage
    {
        private Product product;

        public EditProductPage(Product product)
        {
            InitializeComponent();
            this.product = product;
            FillFields(product);
        }

        private void FillFields(Product product)
        {
            EntryName.Text = product.Name;
            EntryPhoto.Text = product.PhotoUrl ?? "";
            EntryPrice.Text = product.Price.ToString();
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            var name = EntryName.Text;
            var photo = EntryPhoto.Text;
            Decimal price = 0;
            if (!Decimal.TryParse(EntryPrice.Text, out price))
            {
                await DisplayAlert("Invalid Price", "Please, type a valid price", "Ok");
                return;
            }

            product.Name = name;
            product.PhotoUrl = photo;
            product.Price = price;

            await App.Service.UpdateProductAsync(product);
            await Navigation.PopModalAsync(true);
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}