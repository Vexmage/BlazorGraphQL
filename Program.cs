using BlazorGraphQL.Data;
using BlazorGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=books.db"));

// Add GraphQL Services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
