using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductDemo.Domain.Common;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Domain.Aggregates
{
    public class OrderItem : BaseEntity
    {
        
        public int ProductId { get; private set; }
        [ForeignKey("ProductId")]
        public Product Product { get; private set; }
        public int OrderId { get; private set; }
        [ForeignKey("OrderId")]
        public Order Order { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
