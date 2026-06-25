using BlazorGraphQL.Domain.Entities;
using BlazorGraphQL.Infrastructure.Data;

namespace BlazorGraphQL.GraphQL.Queries;

public class BookQuery
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks(AppDbContext context)
    {
        // Simply return the books collection directly without any relational joins
        return context.Books;
    }
}