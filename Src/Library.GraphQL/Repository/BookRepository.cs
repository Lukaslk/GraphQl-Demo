using Library.GraphQL.Infrastructure;
using Library.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Guid id, Book book);
        Task<bool> DeleteAsync(Guid id);
    }
    public class BookRepository(LibraryContext context) : IBookRepository
    {
        public async Task<List<Book>> ListAsync() => await context.Books.ToListAsync();
        public async Task<Book?> GetByIdAsync(Guid id) => await context.Books.FindAsync(id);

        public async Task<Book> AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            return book;
        }

        public async Task<Book> UpdateAsync(Guid id, Book book)
        {
            var result = await GetByIdAsync(id) ?? throw new Exception("Book not found");

            book.Id = id;
            context.Entry(result).CurrentValues.SetValues(book);

            await context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var deleteBook = await GetByIdAsync(id) ?? throw new Exception("Book not found");

            context.Books.Remove(deleteBook);

            var result = await context.SaveChangesAsync();

            return result > 0;
        }
    }

    internal static class RepositoyrBookExtensions
    {
        internal static void AddBookRepository(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
