using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Common;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Domain.Aggregates
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; private set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; private set; }
        public decimal TotalPrice { get; set; }
        private List<OrderItem> _items = new List<OrderItem>();

        public Order(int customerId, decimal totalPrice)
        {
            CustomerId = customerId;
            TotalPrice = totalPrice;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
