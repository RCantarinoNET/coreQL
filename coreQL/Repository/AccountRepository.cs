using coreQL.Contracts;
using coreQL.Entities.Context;

namespace coreQL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly appDbContext _context;

        public AccountRepository(appDbContext context)
        {
            _context = context;
        }
    }
}