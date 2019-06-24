using System.Collections.Generic;
using coreQL.Entities;

namespace coreQL.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }
    
    
    
}