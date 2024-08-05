using Library.GraphQL.Applications.Query;
using Library.GraphQL.Applications.Schemas;
using Library.GraphQL.Infrastructure;
using Library.GraphQL.Repository;
using Library.GraphQL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddLibraryDbContext();
builder.Services.AddBookRepository();
builder.Services.AddTypes();
builder.Services.AddQuery();
builder.Services.AddSchema();
//builder.Services.AddMutation();

builder.Services.AddGraphQlCofigServices();

var app = builder.Build();

DbContextExtensions.Seed(app);

app.UseHttpsRedirection();

app.AddGraphQLMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();