using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace coreQL.Entities.Context
{
    public class OwnerConfig : IEntityTypeConfiguration<Entities.Owner>
    {
        private Guid[] ids;

        public OwnerConfig(Guid[] _ids)
        {
            this.ids = _ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData(new Owner
            {
                Id = ids[0],
                Name = "Renato",
                Address = "Brasilia"
            }, new Owner
            {
                Id = ids[1],
                Name = "Renato",
                Address = "São Paulo"
            });
        }
    }

    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        private Guid[] _ids;

        public AccountConfig(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasData(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeAccount.Cash,
                    Description = "Cash account for our users",
                    OwnerId = _ids[0]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeAccount.Savings,
                    Description = "Savings account for our users",
                    OwnerId = _ids[1]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeAccount.Income,
                    Description = "Income account for our users",
                    OwnerId = _ids[1]
                }
           );
        }
    }
}