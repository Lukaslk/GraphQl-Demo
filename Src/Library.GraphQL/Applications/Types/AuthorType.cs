using GraphQL.Types;
using Library.GraphQL.Models;
using Library.GraphQL.Repository;

namespace Library.GraphQL.Applications.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IBookRepository bookRepository)
        {
            Name = "author";
            Field(p => p.Id);
            Field(p => p.Name);
            Field<ListGraphType<BookType>>("books").ResolveAsync(async context =>
            {
                var authorId = context.Source.Id;
                var books = await bookRepository.ListAsync();

                return books.Where(p => p.AuthorId == authorId);
            });
        }
    }
}
