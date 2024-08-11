using Library.GraphQL.Infrastructure;
using Library.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> ListAsync();
        Task<Author?> GetByIdAsync(Guid id);
        Task<Author> AddAsync(Author author);
        Task<Author> UpdateAsync(Guid id, Author author);
        Task<bool> DeleteAsync(Guid id);
    }
    public class AuthorRepository(LibraryContext context) : IAuthorRepository
    {
        public async Task<List<Author>> ListAsync() => await context.Authors.ToListAsync();
        public async Task<Author?> GetByIdAsync(Guid id) => await context.Authors.FindAsync(id);

        public async Task<Author> AddAsync(Author author)
        {
            await context.Authors.AddAsync(author);

            await context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> UpdateAsync(Guid id, Author author)
        {
            var result = await GetByIdAsync(id) ?? throw new Exception("Author not found");

            author.Id = id;
            context.Entry(result).CurrentValues.SetValues(author);

            await context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var deleteAuthor = await GetByIdAsync(id) ?? throw new Exception("Author not found");

            context.Authors.Remove(deleteAuthor);

            var result = await context.SaveChangesAsync();

            return result > 0;
        }
    }

    internal static class RepositoyrAuthorExtensions
    {
        internal static void AddAuthorRepository(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
        }
    }
}
