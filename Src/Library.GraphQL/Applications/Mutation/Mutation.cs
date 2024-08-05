using Library.GraphQL.Infrastructure;
using Library.GraphQL.Models;

namespace Library.GraphQL.Applications.Mutation
{
    public class Mutation(LibraryContext context) : IMutation
    {
        //private readonly LibraryContext _libraryContext = context;

        public async Task<Book> AddBookAsync(string title, string description, Guid authorId)
        {
            var book = new Book() { Title = title, Description = description, AuthorId = authorId };

            await context.AddAsync(book);
            await context.SaveChangesAsync();

            return book;
        }
    }

    internal static class MutationExtensions
    {
        internal static void AddMutation(this IServiceCollection services)
        {
            services.AddScoped<IMutation, Mutation>();
        }
    }
}
