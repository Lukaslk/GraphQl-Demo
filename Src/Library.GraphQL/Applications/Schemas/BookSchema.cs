using Library.GraphQL.Applications.Query;
using GraphQL.Types;
using Library.GraphQL.Applications.Mutations;

namespace Library.GraphQL.Applications.Schemas
{
    public class BookSchema : Schema
    {
        public BookSchema(BookQuery bookQuery, BookMutation bookMutation) 
        {
            Query = bookQuery;
            Mutation = bookMutation;
        }
    }

    internal static class SchemaExtension
    {
        internal static void AddSchema(this IServiceCollection services)
        {
            services.AddTransient<ISchema, BookSchema>();
        }
    }
}
