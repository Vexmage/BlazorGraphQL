using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Data;
using HotChocolate.Resolvers; // 🚀 ADD THIS FOR ScopedService
using Microsoft.EntityFrameworkCore;
using BlazorGraphQL.Data;
using BlazorGraphQL.Models;


namespace BlazorGraphQL.GraphQL
{
    public class BookMutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<Book> AddBookAsync(
            string title,
            string author,
            [Service] AppDbContext context)
        {
            var book = new Book { Title = title, Author = author };
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Book?> UpdateBookAsync(
            int id,
            string? title,
            string? author,
            [Service] AppDbContext context)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null) return null;

            book.Title = title ?? book.Title;
            book.Author = author ?? book.Author;
            await context.SaveChangesAsync();
            return book;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<bool> DeleteBookAsync(
            int id,
            [Service] AppDbContext context)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null) return false;

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
