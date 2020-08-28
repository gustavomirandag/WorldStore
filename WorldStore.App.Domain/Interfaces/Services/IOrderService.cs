using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
    }
}
