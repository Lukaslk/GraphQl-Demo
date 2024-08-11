using GraphQL.Types;

namespace Library.GraphQL.Applications.Types
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Field<StringGraphType>("name");
        }
    }
}
