using FluentValidation;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u => u.UserForLoginDto.Email).NotEmpty();

        RuleFor(u => u.UserForLoginDto.Password).NotEmpty();
    }
}