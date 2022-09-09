using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserOfficialWebSiteRepository : EfRepositoryBase<UserOfficialWebSite,BaseDbContext> , IUserOfficialWebSiteRepository
{
    public UserOfficialWebSiteRepository(BaseDbContext context) : base(context)
    {
    }
}