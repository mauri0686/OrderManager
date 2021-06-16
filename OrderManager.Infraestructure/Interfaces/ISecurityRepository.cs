using OrderManager.Core.Entities;
using OrderManager.Infrastructure.Repository;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}