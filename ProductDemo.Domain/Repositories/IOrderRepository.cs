using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order> { }
}
