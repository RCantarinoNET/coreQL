using coreQL.QL.Queries;
using GraphQL;
using GraphQL.Types;

namespace coreQL.QL.Schemas
{
    public class AppSchema : Schema
    {

        public AppSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
        }
        
    }
}