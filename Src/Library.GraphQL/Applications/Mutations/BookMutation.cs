using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using Library.GraphQL.Applications.Types;
using Library.GraphQL.Models;
using Library.GraphQL.Repository;

namespace Library.GraphQL.Applications.Mutations
{
    public class BookMutation : ObjectGraphType
    {
        public BookMutation(IBookRepository bookRepository)
        {
            AddField(new()
            {
                Name = "createBook",
                Type = typeof(BookType),
                Arguments = new QueryArguments(new QueryArgument<BookInputType>() { Name = "book" }),
                Resolver = new FuncFieldResolver<Book>(async context => await bookRepository.AddAsync(context.GetArgument<Book>("book"))),
            });

            AddField(new()
            {
                Name = "updateBook",
                Type = typeof(BookType),
                Arguments = new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "idBook" },
                                               new QueryArgument<BookInputType>() { Name = "book" }),
                Resolver = new FuncFieldResolver<Book>(async context => await bookRepository.UpdateAsync(context.GetArgument<Guid>("idBook"),
                                                                                                         context.GetArgument<Book>("book"))),
            });

            AddField(new()
            {
                Name = "deleteBook",
                Type = typeof(BooleanGraphType),
                Arguments = new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "idBook" }),
                Resolver = new FuncFieldResolver<bool>(async context => await bookRepository.DeleteAsync(context.GetArgument<Guid>("idBook"))),
            });
        }
    }
}
