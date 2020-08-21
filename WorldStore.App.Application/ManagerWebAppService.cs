using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WorldStore.App.Application.Models.Dtos;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Application
{
    public class ManagerWebAppService
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

        public Product GetProduct(Guid Product)
        {
            throw new NotImplementedException();
        }

        public bool AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        public bool SignIn(string username, string password)
        {
            token = GetToken(username, password);
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
