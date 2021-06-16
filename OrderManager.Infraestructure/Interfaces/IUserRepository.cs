using OrderManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}