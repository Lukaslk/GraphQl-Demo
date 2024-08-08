using Library.GraphQL.Applications.Schemas;
using Library.GraphQL.Extensions;
using Library.GraphQL.Infrastructure;
using Library.GraphQL.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddLibraryDbContext();
builder.Services.AddBookRepository();
builder.Services.AddTypes();
builder.Services.AddSchema();
builder.Services.AddQuery();
builder.Services.AddMutation();

builder.Services.AddGraphQlCofigServices();

var app = builder.Build();

DbContextExtensions.Seed(app);

app.UseHttpsRedirection();

app.AddGraphQLMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();