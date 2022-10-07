using Application.Features.Auths.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ThisEmailAddressAlreadyHasAnAccount(string email)
    {
        User? user = await _userRepository.GetAsync(u=>u.Email==email);
        if (user != null) throw new BusinessException(AuthMessages.EmailHasTaken);
    }

    public async Task ThereIsNoAccountRegisteredForThisEmailAddress(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user == null) throw new BusinessException(AuthMessages.NoAccount);
    }

    public async Task VerifyPassword(string password,User user)
    {
        if (!HashingHelper.VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
        {
            throw new Exception(AuthMessages.VerifyPassword);
        }
    }
}