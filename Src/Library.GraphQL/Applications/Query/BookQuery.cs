using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using Library.GraphQL.Applications.Types;
using Library.GraphQL.Models;
using Library.GraphQL.Repository;

namespace Library.GraphQL.Applications.Query
{
    public class BookQuery : ObjectGraphType<object>
    {
        public BookQuery(IBookRepository bookRepository)
        {
            AddField(new()
            {
                Name = "books",
                Type = typeof(ListGraphType<BookType>),
                Resolver = new FuncFieldResolver<List<Book>>(async context => await bookRepository.ListAsync()),
            });

            AddField(new()
            {
                Name = "book",
                Type = typeof(BookType),
                Arguments = new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "id" }),
                Resolver = new FuncFieldResolver<Book?>(async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await bookRepository.GetByIdAsync(id);
                }),
            });
        }
    }

    internal static class QueryExtensions
    {
        internal static void AddQuery(this IServiceCollection services)
        {
            services.AddScoped<BookQuery>();
        }
    }
}
