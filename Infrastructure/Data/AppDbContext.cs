using BlazorGraphQL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}