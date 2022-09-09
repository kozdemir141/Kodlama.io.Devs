using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetListProductsByBrand;

public class GetListProductsByBrandQuery : IRequest<ProductListByBrandModel>
{
    public PageRequest PageRequest { get; set; }
    
    public int BrandId { get; set; }

    public class GetListProductsByBrandQueryHandler : IRequestHandler<GetListProductsByBrandQuery, ProductListByBrandModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductsByBrandQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListByBrandModel> Handle(GetListProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(p=>p.BrandId==request.BrandId,
                include: m=>m.Include(p=>p.Brand),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            ProductListByBrandModel productListByBrandModel = _mapper.Map<ProductListByBrandModel>(products);

            return productListByBrandModel;
        }
    }
}