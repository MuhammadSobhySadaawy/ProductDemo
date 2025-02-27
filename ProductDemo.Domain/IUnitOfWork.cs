using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Repositories;

namespace ProductDemo.Domain
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public IOrderRepository orderRepository { get; }
        public Task CommitAsync();
    }

}
