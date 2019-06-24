using Microsoft.EntityFrameworkCore;

namespace coreQL.Entities.Context
{
    public class appDbContext : DbContext
    {
        public static readonly string ConexString = "Server=STFBSBC028976-W\\SQLEXPRESS;Database=MyBank;User Id=dba;Password=s3nh4___;";

        public appDbContext()
        {
        }

        public appDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}