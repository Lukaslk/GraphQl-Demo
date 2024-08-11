using GraphQL.Types;

namespace Library.GraphQL.Applications.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<BookQuery>("bookQuery").Resolve(context => new { });
            Field<AuthorQuery>("authorQuery").Resolve(context => new { });
        }
    }
}
