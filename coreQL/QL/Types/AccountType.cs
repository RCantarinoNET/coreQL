using GraphQL.Types;

namespace coreQL.QL.Types
{
    public class AccountType : ObjectGraphType<Entities.Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id propertie");
            Field(x => x.Description).Description("Desc propertie");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("Id owner propertie");

            Field<AccountTypeEnumType>("Type", "Enumaration");
        }
    }
}