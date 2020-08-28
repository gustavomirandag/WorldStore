using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WorldStore.Common.Domain.Application.CQRS.Messaging;
using WorldStore.Common.Domain.Interfaces.Services;
using WorldStore.Common.Infra.Helper.Serializer;
using WorldStore.Common.Infra.Messaging.Services;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using WorldStore.Microservices.OrderMicroservice.Application.Services;
using WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Contexts;
using WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Repositories;
using WorldStore.Microservices.OrderMicroservice.OrderWorker.Properties;

namespace WorldStore.Microservices.OrderMicroservice.OrderWorker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddServiceBus(sbOptions =>
                {
                    sbOptions.ConnectionString = Resources.ServiceBusConnectionString;
                    sbOptions.MessageHandlerOptions.AutoComplete = true;
                    sbOptions.MessageHandlerOptions.MaxConcurrentCalls = 16;
                });
            }).ConfigureServices(services =>
            {
                services.AddSingleton<IMediatorHandler, AzureServiceBusQueue>();
                services.AddSingleton<IProductQueryRepository, ProductMicroserviceQueryRepository>();
                services.AddSingleton<DbContext, OrderContext>();
                services.AddSingleton<IOrderRepository, OrderRepository>();
                services.AddSingleton<IOrderService, OrderService>();
                services.AddSingleton<IProductQueryService, ProductQueryService>();
                services.AddSingleton<ISerializerService, SerializerService>();
                services.AddSingleton<IWorkerApplicationService, WorkerApplicationService>();
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
