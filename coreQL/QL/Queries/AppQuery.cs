using coreQL.Contracts;
using coreQL.QL.Types;
using GraphQL;
using GraphQL.Types;
using System;

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

            Field<ListGraphType<OwnerType>>(
               "owner",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
               resolve: context =>
               {
                   Guid id;
                   if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                   {
                       context.Errors.Add(new ExecutionError("parse error"));
                   }

                   return repository.GetOwner(id);
               });
        }
    }
}