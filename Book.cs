using System;

namespace BlazorGraphQL;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Category { get; set; } = "Uncategorized"; // e.g., Fiction, Philosophy, etc.

    public string Status { get; set; } = "Wishlist"; // Wishlist, Owned, Reading, Completed

    public string ReflectionNotes { get; set; } = string.Empty; // Notes about the book

    public double Progress { get; set; } = 0.0; // Progress percentage (0-100)
}
