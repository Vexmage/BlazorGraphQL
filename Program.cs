using BlazorGraphQL.Data;
using BlazorGraphQL.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=books.db"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>()
    .AddFiltering()
    .AddSorting()
    .ModifyOptions(o =>
    {
        o.RemoveUnreachableTypes = true; 
    });




builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5206/") });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); 
}


app.UseCors("AllowAll");

app.UseStaticFiles();

app.MapGraphQL();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host"); 

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.Run();
