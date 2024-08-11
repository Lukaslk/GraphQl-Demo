using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using Library.GraphQL.Applications.Types;
using Library.GraphQL.Models;
using Library.GraphQL.Repository;

namespace Library.GraphQL.Applications.Mutations
{
    public class AuthorMutation : ObjectGraphType
    {
        public AuthorMutation(IAuthorRepository authorRepository)
        {
            AddField(new()
            {
                Name = "createAuthor",
                Type = typeof(AuthorType),
                Arguments = new QueryArguments(new QueryArgument<AuthorInputType>() { Name = "author" }),
                Resolver = new FuncFieldResolver<Author>(async context => await authorRepository.AddAsync(context.GetArgument<Author>("author"))),
            });

            AddField(new()
            {
                Name = "updateAuthor",
                Type = typeof(AuthorType),
                Arguments = new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "authorId" },
                                               new QueryArgument<AuthorInputType>() { Name = "author" }),
                Resolver = new FuncFieldResolver<Author>(async context => await authorRepository.UpdateAsync(context.GetArgument<Guid>("authorId"),
                                                                                                             context.GetArgument<Author>("author"))),
            });

            AddField(new()
            {
                Name = "deleteAuthor",
                Type = typeof(BooleanGraphType),
                Arguments = new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "authorId" }),
                Resolver = new FuncFieldResolver<bool>(async context => await authorRepository.DeleteAsync(context.GetArgument<Guid>("authorId"))),
            });
        }
    }
}
