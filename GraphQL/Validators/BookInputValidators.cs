using FluentValidation;
using BlazorGraphQL.GraphQL.Models;

namespace BlazorGraphQL.GraphQL.Validators;

public class AddBookInputValidator : AbstractValidator<AddBookInput>
{
    public AddBookInputValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("A book title is strictly required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("An author name must be specified.")
            .MaximumLength(100).WithMessage("Author name cannot exceed 100 characters.");

        RuleFor(x => x.YearPublished)
            .InclusiveBetween(1400, DateTime.UtcNow.Year + 1)
            .WithMessage($"Year published must be a valid history marker between 1400 and {DateTime.UtcNow.Year + 1}.");

        RuleFor(x => x.Status)
            .Must(status => string.IsNullOrEmpty(status) || status == "Wishlist" || status == "Reading" || status == "Completed")
            .WithMessage("Status must map to an official category value ('Wishlist', 'Reading', or 'Completed').");

        RuleFor(x => x.Progress)
            .InclusiveBetween(0.0, 1.0)
            .When(x => x.Progress.HasValue)
            .WithMessage("Progress metrics must scale as a mathematical decimal fraction between 0.0 and 1.0.");
    }
}