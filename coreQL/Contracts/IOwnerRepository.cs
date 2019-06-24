using coreQL.Entities;
using System;
using System.Collections.Generic;

namespace coreQL.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();

        Owner GetOwner(Guid id);
    }
}