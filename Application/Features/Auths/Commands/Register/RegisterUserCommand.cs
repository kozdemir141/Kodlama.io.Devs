using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register;

public class RegisterUserCommand : IRequest<TokenDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,TokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<TokenDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.ThisEmailAddressAlreadyHasAnAccount(request.Email);
            
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AuthenticatorType = AuthenticatorType.Email
            };
            var createdUser = await _userRepository.AddAsync(user);
            var claims = _userRepository.GetClaims(user);
            var token = _tokenHelper.CreateToken(user,claims);
            
            return new() { Token = token.Token, Expiration = token.Expiration };
        }
    }
}