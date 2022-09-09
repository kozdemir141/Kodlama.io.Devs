using FluentValidation;

namespace Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(b => b.BrandName).NotEmpty();
        RuleFor(b => b.BrandName).MinimumLength(2);
    }
}