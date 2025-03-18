using BlazorGraphQL.Data;
using BlazorGraphQL.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.GraphQL
{
    public class BookMutation
    {
        public async Task<Book> AddBookAsync(
            string title,
            string author,
            string category,
            string status,
            string genre,
            double progress,
            int yearPublished,
            string reflectionNotes,
            [Service] AppDbContext context)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                Category = category,
                Status = status,
                Progress = progress,
                YearPublished = yearPublished,
                ReflectionNotes = reflectionNotes
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        // ✅ **NEW: Delete Book Mutation**
        public async Task<bool> DeleteBookAsync(int id, [Service] AppDbContext context)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return false; // No book found to delete
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
