using Library.GraphQL.Applications.Schemas;
using Library.GraphQL.Extensions;
using Library.GraphQL.Infrastructure;
using Library.GraphQL.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddLibraryDbContext();
builder.Services.AddBookRepository();
builder.Services.AddAuthorRepository();
builder.Services.AddTypes();
builder.Services.AddQuery();
builder.Services.AddMutation();
builder.Services.AddSchema();
builder.Services.AddGraphQlCofigServices();

var app = builder.Build();

DbContextExtensions.InitializeDatabase(app);

app.UseHttpsRedirection();

app.AddGraphQLMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();