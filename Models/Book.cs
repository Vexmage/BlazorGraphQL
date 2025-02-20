using System.ComponentModel.DataAnnotations;

namespace BlazorGraphQL.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public required string Title { get; set; }
        public required string Author { get; set; }

        public string Category { get; set; } = "Uncategorized";
        public string Status { get; set; } = "Wishlist";
        public string ReflectionNotes { get; set; } = string.Empty;
        public double Progress { get; set; } = 0.0;
    }
}
