using BlazorGraphQL.Application.Services;
using BlazorGraphQL.GraphQL.Mutations;
using BlazorGraphQL.GraphQL.Queries;
using BlazorGraphQL.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient("BlazorGraphQLApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5206/");
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorGraphQLApi"));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=books.db"));

builder.Services.AddScoped<BookService>();

// Modernized HotChocolate API Engine Configuration Pipeline
builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>()
    .AddFiltering() // Resolves: HotChocolate.SchemaException (No default filter convention found)
    .AddSorting();  // Smoothly wires IQueryable sorting downstream to your SQLite Context

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapGraphQL();

app.Run();