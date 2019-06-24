using coreQL.Contracts;
using coreQL.QL.Types;
using GraphQL.Types;

namespace coreQL.QL.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context => repository.GetAll()
                );

        }
    }
}