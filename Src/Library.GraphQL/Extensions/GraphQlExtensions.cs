using GraphiQl;
using GraphQL;
using GraphQL.Types;

namespace Library.GraphQL.Extensions
{
    public static class GraphQlExtensions
    {
        public static void AddGraphQlCofigServices(this IServiceCollection services)
        {
            services.AddGraphQL(p => p.AddAutoSchema<ISchema>().AddSystemTextJson());
        }

        public static IApplicationBuilder AddGraphQLMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseGraphiQl("/graphql");
            applicationBuilder.UseGraphQL<ISchema>();

            return applicationBuilder;
        }
    }
}
