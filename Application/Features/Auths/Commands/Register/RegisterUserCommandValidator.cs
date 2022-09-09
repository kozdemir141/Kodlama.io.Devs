using FluentValidation;

namespace Application.Features.Auths.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.FirstName).Length(3, 50);
        RuleFor(u => u.FirstName).Must(StartWithUpperCase);
        
        RuleFor(u => u.LastName).NotEmpty();
        RuleFor(u => u.LastName).Length(3, 50);
        RuleFor(u => u.LastName).Must(StartWithUpperCase);
        
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
        
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.Password).Must(IncludeOneUpperCase);
    }
    private bool IncludeOneUpperCase(string arg)
    {
        bool result = false;

        for (int i = 0; i < arg.Length; i++)
        {
            if (arg[i] == char.ToUpper(arg[i]))
            {
                result = true;
            }
        }
        return result;
    }
    private bool StartWithUpperCase(string arg)
    {
        return arg.StartsWith(char.ToUpper(arg[0]));
    }
}