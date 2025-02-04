using System.ComponentModel.DataAnnotations;

namespace BlazorGraphQL.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
