using GraphQL;
using GraphQL.Types;
using Library.GraphQL.Models;
using Library.GraphQL.Repository;

namespace Library.GraphQL.Applications.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IAuthorRepository authorRepository)
        {
            Name = "book";
            Field(p => p.Id);
            Field(p => p.Title);
            Field(p => p.Description);
            Field(p => p.AuthorId);
            Field<AuthorType>("Author").ResolveAsync(async context =>
                                        {
                                            var authorId = context.Source.AuthorId;
                                            return await authorRepository.GetByIdAsync(authorId);
                                        });
        }
    }
}
