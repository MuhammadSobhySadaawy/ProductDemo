using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Entities;
using ProductDemo.Domain.Repositories;
using ProductDemo.Infrastructure.Data.Db;
using ProductDemo.Infrastructure.Data.Repositories;

namespace ProductDemo.Infrastructure.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private  AppDbContext _context;
         public UnitOfWork(AppDbContext context )
        {
            _context = context;
         }

        private  IProductRepository _productRepository;
        public  IProductRepository productRepository {
            get {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            } 
        }

        private IOrderRepository _orderRepository;
        public IOrderRepository orderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }
                return _orderRepository;
            }
        }
        public async Task CommitAsync()
        {
          await  _context.SaveChangesAsync();
        }

    }
}
