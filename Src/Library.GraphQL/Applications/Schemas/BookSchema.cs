using Library.GraphQL.Applications.Query;
using GraphQL.Types;

namespace Library.GraphQL.Applications.Schemas
{
    public class BookSchema : Schema
    {
        public BookSchema(BookQuery bookQuery) 
        {
            Query = bookQuery;
        }
    }

    internal static class SchemaExtension
    {
        internal static void AddSchema(this IServiceCollection services)
        {
            //services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddTransient<ISchema, BookSchema>();
        }
    }
}
