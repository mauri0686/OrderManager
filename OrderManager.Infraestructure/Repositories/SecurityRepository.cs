using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
using OrderManager.Infrastructure.Data;
using OrderManager.Infrastructure.Repository;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure.Repositories
{
    public class SecurityRepository : Repository<Security>, ISecurityRepository
    {
        public SecurityRepository(OrderContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
