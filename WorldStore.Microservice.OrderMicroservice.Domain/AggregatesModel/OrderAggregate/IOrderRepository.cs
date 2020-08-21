using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Domain.Interfaces.Repositories;

namespace WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository : IRepository<Guid, Order>
    {
    }
}
