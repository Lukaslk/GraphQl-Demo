using Library.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(LibraryContext));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var idAuthorId = Guid.NewGuid();
            modelBuilder.Entity<Book>().HasData(
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Title Test",
                        Description = "Description Test",
                        AuthorId = idAuthorId,
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Title 2 Test",
                        Description = "Description 2 Test",
                        AuthorId = idAuthorId,
                    }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = idAuthorId,
                    Name = "Author Name"
                });

            modelBuilder.Entity<Author>().HasData(
                            new Author()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Author Name 2"
                            });
        }
    }

    public static class DbContextExtensions
    {
        public static IServiceCollection AddLibraryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>();
            return services;
        }

        public static void Seed(WebApplication app)
        {
            var serviceScoprapp = app.Services.CreateScope();
            var dataContext = serviceScoprapp.ServiceProvider.GetService<LibraryContext>();
            dataContext?.Database.EnsureCreated();
        }
    }
}