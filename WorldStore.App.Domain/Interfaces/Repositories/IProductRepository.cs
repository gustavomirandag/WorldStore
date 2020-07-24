using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.App.Domain.Entities;
using WorldStore.Common.Domain.Interfaces.Repositories;

namespace WorldStore.App.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Guid,Product>
    {
    }
}
