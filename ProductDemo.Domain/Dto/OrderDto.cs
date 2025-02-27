using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Domain.Dto
{
    public class OrderDto
    {
        public int CustomerId { get;   set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDto> items { get; set; } = new List<OrderItemDto>();
    }
}
