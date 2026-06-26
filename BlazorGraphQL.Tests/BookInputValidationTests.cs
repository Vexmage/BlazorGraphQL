using Xunit;
using FluentAssertions;
using FluentValidation.Results;
using BlazorGraphQL.GraphQL.Models;
using BlazorGraphQL.GraphQL.Validators;

namespace BlazorGraphQL.Tests;

public class BookInputValidationTests
{
    private readonly AddBookInputValidator _validator;

    public BookInputValidationTests()
    {
        // Setup the validator instance under test
        _validator = new AddBookInputValidator();
    }

    [Fact]
    public void AddBookInput_Should_Pass_When_Payload_Is_Perfectly_Valid()
    {
        // Arrange
        var validPayload = new AddBookInput(
            Title: "The Bed of Procrustes",
            Author: "Nassim Nicholas Taleb",
            Genre: "Philosophy",
            YearPublished: 2010,
            Category: "Philosophical Aphorisms",
            Status: "Wishlist",
            ReflectionNotes: "An exploration of operational constraints.",
            Progress: 0.0
        );

        // Act
        var result = _validator.Validate(validPayload);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    // Fixed: Aligned expectedErrorMessage parameters to match production validator rules
    [InlineData("", "Author Name", "A book title is strictly required.")]
    [InlineData("Valid Title", "", "An author name must be specified.")]
    public void AddBookInput_Should_Fail_When_Required_Text_Fields_Are_Missing(string title, string author, string expectedErrorMessage)
    {
        // Arrange
        var brokenPayload = new AddBookInput(
            Title: title,
            Author: author,
            Genre: "Tech",
            YearPublished: 2024,
            Category: "General",
            Status: "Reading",
            ReflectionNotes: string.Empty,
            Progress: 0.25
        );

        // Act
        var result = _validator.Validate(brokenPayload);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(expectedErrorMessage));
    }

    [Fact]
    public void AddBookInput_Should_Fail_When_YearPublished_Is_Anachronistic()
    {
        // Arrange
        var futuristicPayload = new AddBookInput(
            Title: "Future Horizons",
            Author: "Unknown Time Traveler",
            Genre: "Sci-Fi",
            YearPublished: 2999, // Way outside historical parameters!
            Category: "Speculative",
            Status: "Wishlist",
            ReflectionNotes: string.Empty,
            Progress: 0.0
        );

        // Act
        var result = _validator.Validate(futuristicPayload);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains("Year published must be a valid history marker"));
    }
}