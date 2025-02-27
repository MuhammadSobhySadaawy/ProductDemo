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
    public class OrderItemDto 
    {
        public int ProductId { get; private set; }
     
        public int OrderId { get; private set; }
      
        public int Quantity { get; private set; }
    }
}
