using WorldStoreApp.Views;
using System;
using WorldStore.App.Domain.Services;
using WorldStore.App.Infra.DataAccess.Repositories.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorldStoreApp.Views.Login;
using WorldStore.App.Application;

namespace WorldStoreApp
{
    public partial class App : Application
    {
        public static IAppService AppService { get; set; }
        public static ProductLocalService Service { get; set; }

        public App()
        {
            InitializeComponent();
            AppService = new AppService();
            Service = new ProductLocalService(new SQLiteProductsRepository(Device.RuntimePlatform));
            MainPage = new NavigationPage(new SignInPage());
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
