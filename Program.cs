using BlazorGraphQL.Data;
using BlazorGraphQL.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddBootstrapBlazor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .ModifyOptions(o =>
    {
        o.RemoveUnreachableTypes = true;
    });

builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=books.db");
});

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5206/") });

var app = builder.Build();

// ✅ Correctly handle migrations with DbContextFactory
using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var dbContext = dbFactory.CreateDbContext();
    dbContext.Database.Migrate();
}

app.UseCors("AllowAll");

app.UseStaticFiles();

app.MapGraphQL();


app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/graphql",
    Path = "/playground"
});



app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.Run();
