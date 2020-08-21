using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands
{
    public class OrderCommand
    {
        public Order Order { get; set; }
    }
}
