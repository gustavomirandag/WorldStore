using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using WorldStore.App.Application.Models.Dtos;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Application
{
    public class MobileAppService : IAppService
    {
        private static string token;

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public bool SignIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool SignUp(UserPasswordDto userPassword)
        {
            throw new NotImplementedException();
        }
    }
}
