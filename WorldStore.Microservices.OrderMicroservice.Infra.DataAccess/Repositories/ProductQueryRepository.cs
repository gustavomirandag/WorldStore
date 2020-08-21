using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Common.Domain.Interfaces.Repositories;
using WorldStore.Common.Domain.Interfaces.Services;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class ProductQueryRepository : IQueryRepository<Guid, Product>
    {
        private ISerializerService serializerService;

        public ProductQueryRepository(ISerializerService serializerService)
        {
            this.serializerService = serializerService;
        }

        public IEnumerable<Product> ReadAll()
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = client.GetAsync("https://worldstore-gustavo-product-microservice-api.azurewebsites.net/api/products").Result;

            var serializedProducts = result.Content.ReadAsStringAsync().Result;
            var products = serializerService.Deserialize<IEnumerable<Product>>(serializedProducts);

            return products;   
        }

        public async Task<IEnumerable<Product>> ReadAllAsync()
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await client.GetAsync("https://worldstore-gustavo-product-microservice-api.azurewebsites.net/api/products");

            var serializedProducts = await result.Content.ReadAsStringAsync();
            var products = serializerService.Deserialize<IEnumerable<Product>>(serializedProducts);

            return products;
        }

        public async Task<Product> ReadAsync(Guid id)
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await client.GetAsync("https://worldstore-gustavo-product-microservice-api.azurewebsites.net/api/products/" + id.ToString());

            var serializedProduct = await result.Content.ReadAsStringAsync();
            var product = serializerService.Deserialize<Product>(serializedProduct);

            return product;
        }

        private string GetToken()
        {
            var client = new HttpClient();
            var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://worldstore-gustavo-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "WorldStoreOrderMicroservice_ClientId",
                //ClientSecret = "secret"
            }).Result;

            return response.AccessToken;
        }
    }
}
