using coreQL.Contracts;
using coreQL.Entities;
using coreQL.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace coreQL.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly appDbContext _context;

        public OwnerRepository(appDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();

        public Owner GetOwner(Guid id) => _context.Owners.SingleOrDefault(x => x.Id == id);
    }
}