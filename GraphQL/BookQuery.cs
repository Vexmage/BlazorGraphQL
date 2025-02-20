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
        [UseFiltering]
        [UseSorting]
        public async Task<List<Book>> GetBooksAsync([Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            using var context = dbContextFactory.CreateDbContext();
            return await context.Books.ToListAsync();
        }
    }
}
