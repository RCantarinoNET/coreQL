using System;
using coreQL.Contracts;
using coreQL.Entities;
using coreQL.QL.Mutations;
using coreQL.QL.Types;
using GraphQL;
using GraphQL.Types;

namespace coreQL.QL.Queries
{
    public class AppMutation : ObjectGraphType
    {

        public AppMutation(IOwnerRepository repository)
        {

            Field<OwnerType>("createOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> {Name = "owner"}),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");

                    return repository.Create(owner);
                });


            //update

            Field<OwnerType>(
                "updateOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> {Name = "owner"},
                    new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "Id"}),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    var ownerId = context.GetArgument<Guid>("Id");
                    owner.Id = ownerId;
                    return repository.Update(owner);
                }
            );

            Field<StringGraphType>(
                "deleteOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "ownerId"}),
                resolve: context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    // if (ownerId == null)
                    //{
                    //  context.Errors.Add(new ExecutionError("Owner nao encontrado."));
                    // return null;
                    // }

                    repository.Delete(ownerId);
                    return $"Owner id: {ownerId} deletado com sucesso.";
                }
            );
        }
    }
}