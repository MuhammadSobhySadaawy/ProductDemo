using System.Linq.Expressions;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Entities;
using ProductDemo.Domain.Repositories;
using ProductDemo.Infrastructure.Data.Db;

namespace ProductDemo.Infrastructure.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

   
    }

}