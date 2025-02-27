using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Dto;
using ProductDemo.Domain;
using ProductDemo.Abstraction.Interfaces;
using ProductDemo.Domain.Aggregates;

namespace ProductDemo.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
 

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            var order = new Order(orderDto.CustomerId, orderDto.TotalPrice);
            foreach (var item in orderDto.items)
            {
                order.AddItem(new OrderItem(item.ProductId, item.Quantity));
            }
            await _unitOfWork.orderRepository.Add(order);
            await _unitOfWork.CommitAsync();
        }
    }
}
