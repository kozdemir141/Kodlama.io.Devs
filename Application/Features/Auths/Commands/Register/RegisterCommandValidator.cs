using FluentValidation;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        //FirstName
        RuleFor(u => u.UserForRegisterDto.FirstName).NotEmpty();
        RuleFor(u => u.UserForRegisterDto.FirstName).Length(3, 50);
        RuleFor(u => u.UserForRegisterDto.FirstName).Must(StartWithUpperCase);
        
        //LastName
        RuleFor(u => u.UserForRegisterDto.LastName).NotEmpty();
        RuleFor(u => u.UserForRegisterDto.LastName).Length(3, 50);
        RuleFor(u => u.UserForRegisterDto.LastName).Must(StartWithUpperCase);
        
        //Email
        RuleFor(u => u.UserForRegisterDto.Email).NotEmpty();
        RuleFor(u => u.UserForRegisterDto.Email).EmailAddress();
        
        //Password
        RuleFor(u => u.UserForRegisterDto.Password).NotEmpty();
        RuleFor(u => u.UserForRegisterDto.Password).Must(IncludeOneUpperCase);
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