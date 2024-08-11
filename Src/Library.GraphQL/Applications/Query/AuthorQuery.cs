using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using Library.GraphQL.Applications.Types;
using Library.GraphQL.Models;
using Library.GraphQL.Repository;

namespace Library.GraphQL.Applications.Query
{
    public class AuthorQuery : ObjectGraphType<object>
    {
        public AuthorQuery(IAuthorRepository authorRepository)
        {
            AddField(new()
            {
                Name = "authors",
                Type = typeof(ListGraphType<AuthorType>),
                Resolver = new FuncFieldResolver<List<Author>>(async context => await authorRepository.ListAsync()),
            });

            AddField(new()
            {
                Name = "author",
                Type = typeof(AuthorType),
                Arguments = new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "id" }),
                Resolver = new FuncFieldResolver<Author?>(async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await authorRepository.GetByIdAsync(id);
                }),
            });
        }
    }
}
