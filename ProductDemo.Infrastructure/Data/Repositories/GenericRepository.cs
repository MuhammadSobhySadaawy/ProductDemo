using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Repositories;
using ProductDemo.Infrastructure.Data.Db;

namespace ProductDemo.Infrastructure.Data.Repositories
{
    public abstract class GenericRepository<T>: IRepository<T> where T : class
    {
        protected AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public virtual async  Task<IEnumerable<T>>  All()
        {
           return  await  _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

     
    }
}
