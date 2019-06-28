using GraphQL.Types;
using Remotion.Linq.Clauses.ResultOperators;

namespace coreQL.QL.Mutations
{
    public class OwnerInputType : InputObjectGraphType
    {

        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");

        }
        
    }
}