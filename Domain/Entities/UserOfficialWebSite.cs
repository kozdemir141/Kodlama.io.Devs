using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class UserOfficialWebSite : Entity
{
    public int UserId { get; set; }
    
    public virtual User User { get; set; }

    public string ProfileUrl { get; set; }
}