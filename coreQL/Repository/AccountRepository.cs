using coreQL.Contracts;
using coreQL.Entities;
using coreQL.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreQL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly appDbContext _context;

        public AccountRepository(appDbContext context)
        {
            _context = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var contas = await _context.Accounts.Where(x => ownerIds.Contains(x.OwnerId)).ToListAsync();
            return contas.ToLookup(x => x.OwnerId);
        }

        public IEnumerable<Account> GetAccountsPerOwner(Guid ownerID)
        {
            return _context.Accounts.Where(x => x.OwnerId == ownerID).ToList();
        }
    }
}