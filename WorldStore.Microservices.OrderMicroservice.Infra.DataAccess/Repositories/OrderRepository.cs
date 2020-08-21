using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Infra.DataAccess.Repositories;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class OrderRepository : EntityFrameworkRepositoryBase<Guid, Order>, IOrderRepository
    {
    }
}
