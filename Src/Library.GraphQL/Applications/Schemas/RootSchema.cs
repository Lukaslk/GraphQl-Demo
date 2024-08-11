using GraphQL.Types;
using Library.GraphQL.Applications.Mutations;
using Library.GraphQL.Applications.Query;

namespace Library.GraphQL.Applications.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }

    internal static class SchemaExtension
    {
        internal static void AddSchema(this IServiceCollection services)
        {
            services.AddTransient<ISchema, RootSchema>();
        }
    }
}
