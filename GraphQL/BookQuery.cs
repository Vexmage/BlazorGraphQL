using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Resolvers; // 🚀 ADD THIS FOR ScopedService
using HotChocolate.Data;
using BlazorGraphQL.Data;
using BlazorGraphQL.Models;



namespace BlazorGraphQL.GraphQL
{
    public class BookQuery
    {
        [UseDbContext(typeof(AppDbContext))]

        public IQueryable<Book> GetBooks([Service] AppDbContext context)


        {
            return context.Books;
        }
    }
}
