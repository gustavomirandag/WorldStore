using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Domain.Entities;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace WorldStoreApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //ListProducts(App.Service.GetAllProducts());
            ListProducts();
        }

        public void ListProducts()
        {
            var products = App.AppService.GetAllProducts();

            if (products == null || products.Count() == 0)
            {
                DisplayAlert("Erro ao Tentar obter os Produtos", "Não foi possível obter os produtos disponíveis, tente novamente mais tarde!", "Ok");
                return;
            }

            FlexLayoutProducts.Children.Clear();

            foreach (var product in products)
            {
                var productStackLayout = new StackLayout();
                productStackLayout.WidthRequest = 300;
                productStackLayout.HeightRequest = 400;

                var labelName = new Label();
                labelName.HorizontalOptions = LayoutOptions.CenterAndExpand;
                labelName.VerticalOptions = LayoutOptions.Start;
                labelName.Text = product.Name;

                productStackLayout.Children.Add(labelName);

                var image = new ImageButton();
                image.HorizontalOptions = LayoutOptions.Center;
                if (!String.IsNullOrEmpty(product.PhotoUrl))
                    image.Source = ImageSource.FromUri(new Uri(product.PhotoUrl));
                else
                    image.Source = ImageSource.FromUri(new Uri("https://cdn4.iconfinder.com/data/icons/refresh_cl/256/System/Box_Empty.png"));
                image.Clicked += async (sender, args) => await BuyProductAsync(product);
                productStackLayout.Children.Add(image);

                var labelPrice = new Label();
                labelPrice.HorizontalOptions = LayoutOptions.CenterAndExpand;
                labelPrice.VerticalOptions = LayoutOptions.End;
                labelPrice.Text = product.Price.ToString();

                productStackLayout.Children.Add(labelPrice);

                FlexLayoutProducts.Children.Add(productStackLayout);
            }
        }

        private async Task BuyProductAsync(Product product)
        {
            await App.AppService.BuyProductAsync(product);
            await DisplayAlert("Order Created", "Your order was created! It doesn't mean it's confirmed.", "Ok");
        }
    }
}
