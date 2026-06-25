using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorGraphQL.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public string? Genre { get; set; }
    public string? Category { get; set; }
    public string Status { get; set; } = "Wishlist";
    public double Progress { get; set; } = 0.0;
    public int YearPublished { get; set; }
    public string? ReflectionNotes { get; set; }

    // HotChocolateIgnore keeps it out of the GraphQL Schema
    // NotMapped keeps it out of the SQLite physical columns
    [HotChocolate.GraphQLIgnore]
    [NotMapped] // <--- CRITICAL FIX: Stops EF Core from creating a database column
    public int ProgressDisplay
    {
        get => (int)(Progress * 100);
        set => Progress = value / 100.0;
    }
}