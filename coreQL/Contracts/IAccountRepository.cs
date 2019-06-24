using coreQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreQL.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccountsPerOwner(Guid ownerID);

        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);
    }
}