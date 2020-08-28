using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorldStore.Common.Domain.Application.CQRS.Messaging;
using WorldStore.Common.Domain.Interfaces.Services;
using WorldStore.Common.Infra.Helper.Serializer;
using WorldStore.Common.Infra.Messaging.Services;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using WorldStore.Microservices.OrderMicroservice.Application.Services;
using WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Contexts;
using WorldStore.Microservices.OrderMicroservice.Infra.DataAccess.Repositories;

namespace WorldStore.Microservices.OrderMicroservice.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<OrderContext>();
            services.AddScoped<IMediatorHandler, AzureServiceBusQueue>();
            services.AddScoped<IProductQueryRepository, ProductMicroserviceQueryRepository>();
            services.AddScoped<DbContext, OrderContext>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<ISerializerService, SerializerService>();
            services.AddScoped<IApiApplicationService, ApiApplicationService>();

            services.AddAuthorization();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://worldstore-gustavo-iammicroservice-identity.azurewebsites.net";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "OrderMicroservice_ApiResource";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
