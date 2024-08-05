using Library.GraphQL.Models;

namespace Library.GraphQL.Applications.Mutation
{
    public interface IMutation
    {
        Task<Book> AddBookAsync(string title, string description, Guid authorId);
    }
}
