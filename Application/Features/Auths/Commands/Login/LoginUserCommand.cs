using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginUserCommand : IRequest<TokenDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,TokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<TokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.ThereIsNoAccountRegisteredForThisEmailAddress(request.Email);
            
            var user = await _userRepository.GetAsync(u => u.Email == request.Email);
            
            await _authBusinessRules.VerifyPassword(request.Password, user);
            
            var claims = _userRepository.GetClaims(user);
            var token = _tokenHelper.CreateToken(user,claims);
            return new() { Token = token.Token, Expiration = token.Expiration };
        }
    }
}