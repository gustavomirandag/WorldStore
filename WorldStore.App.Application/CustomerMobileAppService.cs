using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Application.Models.Dtos;
using WorldStore.App.Domain.Entities;
using WorldStore.App.Domain.Interfaces.Services;
using WorldStore.App.Domain.Services;
using WorldStore.App.Infra.DataAccess.Repositories.Orders;
using WorldStore.Common.Domain.Interfaces.Services;
using WorldStore.Common.Infra.Helper.Serializer;

namespace WorldStore.App.Application
{
    public class CustomerMobileAppService : IAppService
    { 
        private string token;

        public IEnumerable<Product> GetAllProducts()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = client.GetAsync("https://worldstore-gustavo-product-microservice-api.azurewebsites.net/api/products").Result;

            var serializedProducts = result.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(serializedProducts);

            return products;
        }

        public async Task BuyProductAsync(Product product)
        {
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                ProductId = product.Id,
                Price = product.Price,
                SKU = product.SKU,
                Quantity = 1,
            };
            var orderItems = new List<OrderItem>();
            orderItems.Add(orderItem);

            var order = new Order();
            order.OrderItems = orderItems;

            var orderService = new OrderRemoteService(new OrderMicroserviceRepository(token, new SerializerService()));
            await orderService.CreateOrderAsync(order);
        }

        public bool SignIn(string username, string password)
        {
            token = GetToken(username,password);
            if (String.IsNullOrEmpty(token))
                return false;
            return true;
        }

        public bool SignUp(UserPasswordDto userPassword)
        {
            var token = GetAdminToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var serializedUserPassword = JsonConvert.SerializeObject(userPassword);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://worldstore-gustavo-iammicroservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

            if (!result.IsSuccessStatusCode)
                return false;
            return true;
        }

        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://worldstore-gustavo-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "WorldStoreCustomerMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = "admin",
                Password = "@dsInf123"
            }).Result;

            return response.AccessToken;
        }

        private string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://worldstore-gustavo-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "WorldStoreCustomerMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }
    }
}
