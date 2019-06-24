using coreQL.Entities;
using GraphQL.Types;

namespace coreQL.QL.Types
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Type Enumaration";
        }
    }
}