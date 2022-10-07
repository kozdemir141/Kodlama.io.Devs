using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Create UserOperationClaim
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        
        //Delete UserOperationClaim
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
        
        //Update OperationClaim
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        
        //GetLis tOperationClaim
        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
        CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();
    }
}