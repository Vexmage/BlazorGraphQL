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
}