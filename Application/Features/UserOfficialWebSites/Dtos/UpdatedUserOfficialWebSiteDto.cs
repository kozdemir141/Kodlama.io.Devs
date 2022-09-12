namespace Application.Features.UserOfficialWebSites.Dtos;

public class UpdatedUserOfficialWebSiteDto
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string ProfileUrl { get; set; }
}