using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Application.Interfaces.CQRS.Commands;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands
{
    public abstract class OrderCommand : Command
    {
        public Order Order { get; set; }
    }
}
