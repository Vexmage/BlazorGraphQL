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
            using var context = dbContextFactory.CreateDbContext();
            return context.Books.AsQueryable();
        }


    }
}
