using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.SoftDeleteCategory;
using Application.Features.Categories.Commands.UndoDeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateCategory
        CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        
        //DeleteCategory
        CreateMap<Category, DeletedCategoryDto>().ReverseMap();
        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        
        //SoftDeleteCategory
        CreateMap<Category, SoftDeletedCategoryDto>().ReverseMap();
        CreateMap<Category, SoftDeleteCategoryCommand>().ReverseMap();
        
        //UndoDeleteCategory
        CreateMap<Category, UndoDeletedCategoryDto>().ReverseMap();
        CreateMap<Category, UndoDeleteCategoryCommand>().ReverseMap();
        
        //UpdateCategory
        CreateMap<Category, UpdatedCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        
        //GetListCategory
        CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
        CreateMap<Category, CategoryListDto>().ReverseMap();
        
        //GetNonDeletedListCategory
        CreateMap<IPaginate<Category>, CategoryNonDeletedListModel>().ReverseMap();
        CreateMap<Category, CategoryNonDeletedListDto>().ReverseMap();
        
        //GetByIdCategory
        CreateMap<Category, CategoryGetByIdDto>().ReverseMap();
    }
}