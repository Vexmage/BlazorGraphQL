using BlazorGraphQL.Domain.Entities;
using BlazorGraphQL.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.Application.Services;

public class BookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }
    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<Book?> UpdateBookAsync(
    int id,
    string? status,
    double? progress)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null)
            return null;

        if (status is not null)
            book.Status = status;

        if (progress is not null)
            book.Progress = progress.Value;

        await _context.SaveChangesAsync();

        return book;
    }

}