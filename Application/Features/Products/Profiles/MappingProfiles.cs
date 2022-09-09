using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.SoftDeleteProduct;
using Application.Features.Products.Commands.UndoDeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateProduct
        CreateMap<Product, CreatedProductDto>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        
        //DeleteProduct
        CreateMap<Product, DeletedProductDto>().ReverseMap();
        CreateMap<Product, DeleteProductCommand>().ReverseMap();
        
        //SoftDeleteProduct
        CreateMap<Product, SoftDeletedProductDto>().ReverseMap();
        CreateMap<Product, SoftDeleteProductCommand>().ReverseMap();
        
        //UndoDeleteProduct
        CreateMap<Product, UndoDeletedProductDto>().ReverseMap();
        CreateMap<Product, UndoDeleteProductCommand>().ReverseMap();
        
        //UpdateProduct
        CreateMap<Product, UpdatedProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        
        //GetListProduct
        CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
        CreateMap<Product, ProductListDto>().ForMember(p=>p.BrandName,opt=>opt.MapFrom(b=>b.Brand.BrandName))
            .ReverseMap();
        
        //GetNonDeletedListProduct
        CreateMap<IPaginate<Product>, ProductNonDeletedListModel>().ReverseMap();
        CreateMap<Product, ProductNonDeletedListDto>().ForMember(p=>p.BrandName,opt=>opt.MapFrom(b=>b.Brand.BrandName))
            .ReverseMap();
        
        //GetListProductByCategory
        CreateMap<IPaginate<Product>, ProductListByCategoryModel>().ReverseMap();
        CreateMap<Product, ProductListByCategoryDto>().ForMember(p=>p.BrandName,opt=>opt.MapFrom(b=>b.Brand.BrandName))
            .ReverseMap();
        
        //GetListProductByBrand
        CreateMap<IPaginate<Product>, ProductListByBrandModel>().ReverseMap();
        CreateMap<Product, ProductListByBrandDto>().ForMember(p=>p.BrandName,opt=>opt.MapFrom(b=>b.Brand.BrandName))
            .ReverseMap();
        
        //GetByIdProduct
        CreateMap<Product, ProductGetByIdDto>().ReverseMap();
    }
}