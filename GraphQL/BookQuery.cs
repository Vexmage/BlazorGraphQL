using BlazorGraphQL.Data;
using BlazorGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.GraphQL
{
    public class BookQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<Book>> GetBooks([Service] AppDbContext context)
        {
            return await context.Books.ToListAsync();
        }
    }
}
