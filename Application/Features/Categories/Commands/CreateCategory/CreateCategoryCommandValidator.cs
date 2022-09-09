using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryName).NotEmpty();
        RuleFor(c => c.CategoryName).MinimumLength(2);
    }
}