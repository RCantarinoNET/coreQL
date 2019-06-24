using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace coreQL.Entities.Context
{
    public class Dump
    {
        public static void Initialize(DbContextOptions opt)
        {
            using (var context = new Context.appDbContext(opt))
            {
                if (context.Owners.Any()) // caso populado
                    return;

                var _ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
                var o1 = new Owner
                {
                    Id = _ids[0],
                    Name = "Renato",
                    Address = "Brasilia"
                };
                var o2 = new Owner
                {
                    Id = _ids[1],
                    Name = "Renato",
                    Address = "São Paulo"
                };

                context.Owners.Add(o1);
                context.Owners.Add(o2);

                var c1 = new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeAccount.Cash,
                    Description = "Cash account for our users",
                    OwnerId = _ids[0]
                };
                var c2 = new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeAccount.Savings,
                    Description = "Savings account for our users",
                    OwnerId = _ids[1]
                };
                var c3 = new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeAccount.Income,
                    Description = "Income account for our users",
                    OwnerId = _ids[1]
                };

                context.Accounts.Add(c1);
                context.Accounts.Add(c2);
                context.Accounts.Add(c3);

                context
                    .SaveChanges();
            }
        }
    }
}