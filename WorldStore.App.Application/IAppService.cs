using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.App.Application.Models.Dtos;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Application
{
    public interface IAppService
    {
        bool SignIn(string username, string password);
        bool SignUp(UserPasswordDto userPassword);
        IEnumerable<Product> GetAllProducts();
    }
}
