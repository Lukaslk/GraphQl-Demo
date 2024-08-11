using GraphQL.Types;

namespace Library.GraphQL.Applications.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<BookMutation>("bookMutation").Resolve(context => new { });
            Field<AuthorMutation>("authorMutation").Resolve(context => new { });
        }
    }
}
