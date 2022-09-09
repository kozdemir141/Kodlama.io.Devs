using FluentValidation;

namespace Application.Features.Auths.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(u => u.Email).NotEmpty();

        RuleFor(u => u.Password).NotEmpty();
    }
}