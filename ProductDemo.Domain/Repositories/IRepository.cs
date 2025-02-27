using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ProductDemo.Domain.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> All();
        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        public Task<T> Add(T entity);
        public Task SaveChange();
    }
}
