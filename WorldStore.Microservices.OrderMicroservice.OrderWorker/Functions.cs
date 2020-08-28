using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WorldStore.Common.Domain.Interfaces.Services;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands;
using WorldStore.Microservices.OrderMicroservice.Application.Services;

namespace WorldStore.Microservices.OrderMicroservice.OrderWorker
{
    public class Functions
    {
        IWorkerApplicationService workerApplicationService;
        ISerializerService serializerService;

        public Functions(IWorkerApplicationService workerApplicationService, ISerializerService serializerService)
        {
            this.workerApplicationService = workerApplicationService;
            this.serializerService = serializerService;
        }

        public void ProcessAddProductCommand([ServiceBusTrigger(ProcessOrderCommand.CommandQueueName)] string message, ILogger logger)
        {
            logger.LogInformation(message);
            var command = serializerService.Deserialize<ProcessOrderCommand>(message);
            workerApplicationService.ProcessOrderAsync(command).Wait();
        }
    }
}
