using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;

namespace WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderService : IOrderService
    {
        private IProductQueryService productQueryService;
        private IOrderRepository orderRepository;

        public OrderService(IProductQueryService productQueryService, IOrderRepository orderRepository)
        {
            this.productQueryService = productQueryService;
            this.orderRepository = orderRepository;
        }

        public Order CreateOrder(Guid customerId, IReadOnlyCollection<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                CustomerId = customerId,
                OrderItems = orderItems
            };

            return order;
        }

        public async Task<bool> ProcessOrderAsync(Order order)
        {
            foreach(var orderItem in order.OrderItems)
            {
                var product = await productQueryService.GetProductAsync(orderItem.ProductId);

                //Product IsValid?
                if (product == null)
                    return false;

                //Product.Quantity need to be >= OrderItem.Quantity
                if (product.Quantity < orderItem.Quantity)
                    return false;
            }

            //Subtract each product stock quantity in ProductMicroservice 
            //ProductCommandRepository
            //If fails... return false
           
            await orderRepository.CreateAsync(order);
            return await orderRepository.SaveChangesAsync()>0;
        }
    }
}
