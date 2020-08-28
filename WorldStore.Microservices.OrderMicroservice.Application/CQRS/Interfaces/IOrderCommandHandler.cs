using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Interfaces
{
    public interface IOrderCommandHandler
    {
        Task<bool> HandleAsync(ProcessOrderCommand processOrderCommand);
    }
}
