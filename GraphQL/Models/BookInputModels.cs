namespace BlazorGraphQL.GraphQL.Models;

// Explicit Input DTO for Adding a Book
public record AddBookInput(
    string Title,
    string Author,
    string? Genre,
    int YearPublished,
    string? Category,
    string? Status,
    string? ReflectionNotes,
    double? Progress
);

// Explicit Input DTO for Updating a Book
public record UpdateBookInput(
    int Id,
    string? Status,
    double? Progress
);