using FluentValidation;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryName).NotEmpty();
        RuleFor(c => c.CategoryName).MinimumLength(2);
    }
}