using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.ProductName).MinimumLength(2);
        
        RuleFor(p => p.Content).NotEmpty();
        RuleFor(p => p.Content).MinimumLength(8);
        
        RuleFor(p => p.CategoryId).NotEmpty();
        RuleFor(p => p.CategoryId).GreaterThan(0);
        
        RuleFor(p => p.BrandId).NotEmpty();
        RuleFor(p => p.BrandId).GreaterThan(0);
        
        RuleFor(p => p.UnitPrice).NotEmpty();
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
        
        RuleFor(p => p.ProductName).Must(StartWithUpperCase);
    }
    private bool StartWithUpperCase(string arg)
    {
        return arg.StartsWith(char.ToUpper(arg[0]));
    }
}