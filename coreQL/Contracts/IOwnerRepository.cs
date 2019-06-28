using coreQL.Entities;
using System;
using System.Collections.Generic;

namespace coreQL.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();

        Owner GetOwner(Guid id);
        
        Owner Create(Owner owner);
        
        Owner Update(Owner owner);

        void Delete(Guid OwnerId);

        
        
    }
}