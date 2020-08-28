using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands;

namespace WorldStore.Microservices.OrderMicroservice.Application.Services
{
    public interface IWorkerApplicationService
    {
        Task ProcessOrderAsync(ProcessOrderCommand processOrderCommand);
    }
}
