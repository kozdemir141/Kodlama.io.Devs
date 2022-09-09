using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserOfficialWebSiteRepository : IAsyncRepository<UserOfficialWebSite>,IRepository<UserOfficialWebSite>
{
    
}