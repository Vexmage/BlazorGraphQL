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
    }
}
