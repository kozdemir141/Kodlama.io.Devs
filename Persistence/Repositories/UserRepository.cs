using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User,BaseDbContext> , IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }

    public IList<OperationClaim> GetClaims(User user)
    {
        var result = from OperationClaim in Context.OperationClaims
            join UserOperationClaim in Context.UserOperationClaims

                on OperationClaim.Id equals UserOperationClaim.OperationClaimId
            where UserOperationClaim.UserId == user.Id

            select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };

        return result.ToList();
    }
}