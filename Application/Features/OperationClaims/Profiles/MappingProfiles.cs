using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Create OperationClaim
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
        
        //Delete OperationClaim
        CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        
        //Update OperationClaim
        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        
        //GetLis tOperationClaim
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
    }
}