using GraphQL.Types;

namespace Library.GraphQL.Applications.Types
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Field<StringGraphType>("title");
            Field<StringGraphType>("description");
            Field< GuidGraphType>("authorId");
        }
    }
}
