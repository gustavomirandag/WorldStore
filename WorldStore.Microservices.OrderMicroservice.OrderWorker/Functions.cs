using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Common.Domain.Interfaces.Services;
using WorldStore.Common.Infra.Helper.Serializer;
using WorldStore.Common.Infra.Messaging.Services;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands;
using WorldStore.Microservices.OrderMicroservice.Application.Services;
using WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Contexts;
using WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Repositories;

namespace WorldStore.Microservices.OrderMicroservice.OrderWorker
{
    public class Functions
    {
        private static IWorkerApplicationService workerApplicationService = new WorkerApplicationService(new OrderCommandHandler(new OrderService(new ProductQueryService(new ProductMicroserviceQueryRepository(new SerializerService())), new OrderRepository(new OrderContext()))), new AzureServiceBusQueue());
        private static ISerializerService serializerService = new SerializerService();

        //public Functions(IWorkerApplicationService workerApplicationService, ISerializerService serializerService)
        //{
        //    this.workerApplicationService = workerApplicationService;
        //    this.serializerService = serializerService;
        //}

        //[Singleton("ProductUpdateLock", SingletonScope.Host)]
        public static async Task ProcessOrderCommandFunction([ServiceBusTrigger(ProcessOrderCommand.CommandQueueName)] string message, ILogger logger)
        {
            logger.LogInformation(message);
            var command = serializerService.Deserialize<ProcessOrderCommand>(message);
            await workerApplicationService.ProcessOrderAsync(command);
        }
    }
}
