using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Application.Models.Dtos;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Application
{
    public interface IAppService
    {
        Task BuyProductAsync(Product product);
        bool SignIn(string username, string password);
        bool SignUp(UserPasswordDto userPassword);
        IEnumerable<Product> GetAllProducts();
    }
}
