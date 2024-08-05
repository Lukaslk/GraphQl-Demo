using GraphQL.Types;
using Library.GraphQL.Models;

namespace Library.GraphQL.Applications.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "book";
            Field(p => p.Id);
            Field(p => p.Title);
            Field(p => p.Description);
            Field(p => p.AuthorId);
        }
    }
}
