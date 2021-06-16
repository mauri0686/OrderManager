using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
using System.Threading.Tasks;

namespace OrderManager.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;

        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _securityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _securityRepository.Insert(security);
            await _securityRepository.SaveChanges();
        }
    }
}