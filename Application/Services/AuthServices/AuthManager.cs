using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AuthServices;

public class AuthManager : IAuthService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthManager(ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository)
    {
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u =>
                    u.Include(u => u.OperationClaim)
            );
        IList<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);

        return accessToken;
    }

    public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return refreshToken;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken createdRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return createdRefreshToken;
    }
}