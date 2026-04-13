using BlazorGraphQL.Application.Services;
using BlazorGraphQL.Domain.Entities;

namespace BlazorGraphQL.GraphQL.Queries;

public class BookQuery
{
    public async Task<List<Book>> GetBooks([Service] BookService bookService)
    {
        return await bookService.GetAllBooksAsync();
    }
}