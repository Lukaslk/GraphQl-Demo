using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Library.GraphQL.Applications.Mutations;
using Library.GraphQL.Applications.Query;
using Library.GraphQL.Applications.Types;

namespace Library.GraphQL.Extensions
{
    internal static class GraphQlExtensions
    {
        internal static void AddGraphQlCofigServices(this IServiceCollection services)
        {
            services.AddGraphQL(p => p.AddAutoSchema<ISchema>().AddSystemTextJson());
        }

        internal static IApplicationBuilder AddGraphQLMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseGraphiQl("/graphql");
            applicationBuilder.UseGraphQL<ISchema>();

            return applicationBuilder;
        }

        internal static void AddQuery(this IServiceCollection services)
        {
            services.AddScoped<BookQuery>();
        }

        internal static void AddMutation(this IServiceCollection services)
        {
            services.AddScoped<BookMutation>();
        }

        internal static void AddTypes(this IServiceCollection services)
        {
            services.AddTransient<BookType>();
        }
    }
}
