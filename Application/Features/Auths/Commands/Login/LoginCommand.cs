using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthServices;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }


    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

            await _authBusinessRules.ThereIsNoAccountRegisteredForThisEmailAddress(request.UserForLoginDto.Email);
            await _authBusinessRules.VerifyPassword(request.UserForLoginDto.Password, user);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            RefreshToken? getRefreshTokenByUserId = await _refreshTokenRepository.GetAsync(u => u.UserId == user.Id);

            LoggedDto loggedDto = new()
            {
                RefreshToken = getRefreshTokenByUserId,
                AccessToken = createdAccessToken,
            };

            return loggedDto;
        }
    }
}