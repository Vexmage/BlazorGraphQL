using BlazorGraphQL.Data;
using BlazorGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.GraphQL
{
    public class BookQuery
    {
        [UseDbContext(typeof(AppDbContext))] // No change needed
        public IQueryable<Book> GetBooks([Service(ServiceKind.Pooled)] AppDbContext context)
        {
            return context.Books;
        }
    }
}
