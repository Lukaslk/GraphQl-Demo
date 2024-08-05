using Library.GraphQL.Applications.Types;

namespace Library.GraphQL.Extensions
{
    public static class TypeExtensions
    {
        public static void AddTypes(this IServiceCollection services)
        {
            services.AddTransient<BookType>();
        }
    }
}
