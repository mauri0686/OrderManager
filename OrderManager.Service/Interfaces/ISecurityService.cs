using OrderManager.Core.Entities;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}