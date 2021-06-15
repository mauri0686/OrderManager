 
using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;
using OrderManager.Infrastructure.Data;
using OrderManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure.Repository
{
   public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        #region property
        private readonly OrderContext _orderContext;
        private readonly DbSet<T> entities;
        #endregion

        #region Constructor
        public Repository(OrderContext applicationDbContext)
        {
            _orderContext = applicationDbContext;
            entities = _orderContext.Set<T>();
        }
        #endregion

        public async Task Delete(T entity)
        {
            
            entities.Remove(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<T> Get(int Id)
        {
            return await entities.SingleOrDefaultAsync(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public async Task Insert(T entity)
        {
            
            entities.Add(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {            
            entities.Remove(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _orderContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            entities.Update(entity);
            await _orderContext.SaveChangesAsync();
        }

    }
}
