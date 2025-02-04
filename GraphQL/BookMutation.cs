using BlazorGraphQL.Data;
using BlazorGraphQL.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace BlazorGraphQL.GraphQL
{
    public class BookMutation
    {
        public async Task<Book> AddBookAsync(string title, string author, [Service] AppDbContext context)
        {
            var book = new Book { Title = title, Author = author };
            context.Books.Add(book);
            await context.SaveChangesAsync();  
            return book;
        }

    }
}
