using BlazorGraphQL.Data;
using BlazorGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.GraphQL
{
    public class BookQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var context = dbContextFactory.CreateDbContext();
            return context.Books.AsQueryable();
        }

        // 🔍 Search for books by title or author
        public async Task<List<Book>> SearchBooksAsync(string search, [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var context = dbContextFactory.CreateDbContext();
            return await context.Books
                .Where(b => b.Title.Contains(search) || b.Author.Contains(search))
                .ToListAsync();
        }
    }
}
