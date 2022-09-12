using Application.Features.UserOfficialWebSites.Commands.CreateUserOfficialWebSite;
using Application.Features.UserOfficialWebSites.Commands.DeleteUserOfficialWebSite;
using Application.Features.UserOfficialWebSites.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserOfficialWebSites.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateUserOfficialWebSiteCommand
        
        CreateMap<UserOfficialWebSite, CreatedUserOfficialWebSiteDto>().ReverseMap();
        CreateMap<UserOfficialWebSite, CreateUserOfficialWebSiteCommand>().ReverseMap();
        
        //DeleteUserOfficialWebSiteCommand
        
        CreateMap<UserOfficialWebSite, DeletedUserOfficialWebSiteDto>().ReverseMap();
        CreateMap<UserOfficialWebSite, DeleteUserOfficialWebSiteCommand>().ReverseMap();
    }
}