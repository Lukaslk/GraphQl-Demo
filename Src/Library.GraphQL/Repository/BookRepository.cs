using Library.GraphQL.Infrastructure;
using Library.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAsync();
        Task<Book?> GetByIdAsync(Guid id);
    }
    public class BookRepository(LibraryContext context) : IBookRepository
    {
        public async Task<List<Book>> ListAsync() => await context.Books.ToListAsync();
        public async Task<Book?> GetByIdAsync(Guid id) => await context.Books.FirstOrDefaultAsync(p => p.Id == id);
    }

    internal static class RepositoyrBookExtensions
    {
        internal static void AddBookRepository(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
