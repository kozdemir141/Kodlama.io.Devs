using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.SoftDeleteBrand;
using Application.Features.Brands.Commands.UndoDeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateBrand
        CreateMap<Brand, CreatedBrandDto>().ReverseMap();
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        
        //DeleteBrand
        CreateMap<Brand, DeletedBrandDto>().ReverseMap();
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        
        //SoftDeleteBrand
        CreateMap<Brand, SoftDeletedBrandDto>().ReverseMap();
        CreateMap<Brand, SoftDeleteBrandCommand>().ReverseMap();
        
        //UndoDeleteBrand
        CreateMap<Brand, UndoDeletedBrandDto>().ReverseMap();
        CreateMap<Brand, UndoDeleteBrandCommand>().ReverseMap();
        
        //UpdateBrand
        CreateMap<Brand, UpdatedBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        
        //GetListBrand
        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
        CreateMap<Brand, BrandListDto>().ReverseMap();
        
        //GetNonDeletedListBrand
        CreateMap<IPaginate<Brand>, BrandNonDeletedListModel>().ReverseMap();
        CreateMap<Brand, BrandNonDeletedListDto>().ReverseMap();
        
        //GetByIdBrand
        CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
    }
}