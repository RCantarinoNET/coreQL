using System;
using Microsoft.EntityFrameworkCore;

namespace coreQL.Entities.Context
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] {Guid.NewGuid(), Guid.NewGuid()};
            
            
        }
        
        
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account>  Accounts { get; set; }

        
        
    }
}