 
using OrderManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure.Repository
{
   public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task <T> Get(int Id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Remove(T entity);
        Task SaveChanges();
    }
}
