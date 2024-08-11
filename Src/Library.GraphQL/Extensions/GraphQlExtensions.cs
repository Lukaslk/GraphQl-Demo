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

        internal static IApplicationBuilder AddGraphQLMiddleware(this IApplicationBuilder app)
        {
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            return app;
        }

        internal static void AddQuery(this IServiceCollection services)
        {
            services.AddTransient<BookQuery>();
            services.AddTransient<AuthorQuery>();
            services.AddTransient<RootQuery>();

        }

        internal static void AddMutation(this IServiceCollection services)
        {
            services.AddTransient<BookMutation>();
            services.AddTransient<AuthorMutation>();
            services.AddTransient<RootMutation>();
        }

        internal static void AddTypes(this IServiceCollection services)
        {
            services.AddTransient<BookType>();
            services.AddTransient<AuthorType>();
            services.AddTransient<AuthorInputType>();
            services.AddTransient<BookInputType>();
        }
    }
}
