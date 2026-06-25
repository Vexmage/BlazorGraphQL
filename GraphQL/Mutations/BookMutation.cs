using BlazorGraphQL.Application.Services;
using BlazorGraphQL.Domain.Entities;

namespace BlazorGraphQL.GraphQL.Mutations;

public class BookMutation
{
    // Modern HotChocolate automatically binds services registered in Program.cs
    // without requiring the deprecated [Service] parameter attribute decorator.
    public async Task<Book> AddBook(
        string title,
        string author,
        string? genre,
        int yearPublished,
        string? category,
        string? status,
        string? reflectionNotes,
        double? progress,
        BookService bookService)
    {
        var book = new Book
        {
            Title = title,
            Author = author,
            Genre = genre ?? "",
            YearPublished = yearPublished,
            Category = category ?? "Uncategorized",
            Status = status ?? "Wishlist",
            ReflectionNotes = reflectionNotes ?? string.Empty,
            Progress = progress ?? 0.0
        };

        return await bookService.AddBookAsync(book);
    }

    public async Task<bool> DeleteBook(
        int id,
        BookService bookService)
    {
        return await bookService.DeleteBookAsync(id);
    }

    public async Task<Book?> UpdateBook(
        int id,
        string? status,
        double? progress,
        BookService bookService)
    {
        return await bookService.UpdateBookAsync(id, status, progress);
    }
}