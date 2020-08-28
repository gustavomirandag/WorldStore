using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
    }
}
