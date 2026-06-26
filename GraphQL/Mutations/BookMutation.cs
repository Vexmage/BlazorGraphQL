using BlazorGraphQL.Application.Services;
using BlazorGraphQL.Domain.Entities;
using BlazorGraphQL.GraphQL.Models;
using FluentValidation;

namespace BlazorGraphQL.GraphQL.Mutations;

public class BookMutation
{
    public async Task<Book> AddBook(
        AddBookInput input,
        BookService bookService,
        IValidator<AddBookInput> validator)
    {
        // Enforce FluentValidation payload validation rules right at the API gate
        var validationResult = await validator.ValidateAsync(input);
        if (!validationResult.IsValid)
        {
            // Combines errors into a standard message string and leverages HotChocolate error architecture
            var errorDetails = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ArgumentException(errorDetails);
        }

        var book = new Book
        {
            Title = input.Title,
            Author = input.Author,
            Genre = input.Genre ?? "",
            YearPublished = input.YearPublished,
            Category = input.Category ?? "Uncategorized",
            Status = input.Status ?? "Wishlist",
            ReflectionNotes = input.ReflectionNotes ?? string.Empty,
            Progress = input.Progress ?? 0.0
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
        UpdateBookInput input,
        BookService bookService)
    {
        return await bookService.UpdateBookAsync(input.Id, input.Status, input.Progress);
    }
}