using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Dto;

namespace ProductDemo.Abstraction.Interfaces
{
    public interface IOrderService
    {
    public    Task AddOrderAsync(OrderDto orderDto);
    }
}
