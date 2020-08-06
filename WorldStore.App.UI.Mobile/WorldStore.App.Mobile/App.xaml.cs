using WorldStoreApp.Views;
using System;
using WorldStore.App.Domain.Services;
using WorldStore.App.Infra.DataAccess.Repositories.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldStoreApp
{
    public partial class App : Application
    {
        public static ProductLocalService Service { get; set; }

        public App()
        {
            InitializeComponent();
            Service = new ProductLocalService(new SQLiteProductsRepository(Device.RuntimePlatform));
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
