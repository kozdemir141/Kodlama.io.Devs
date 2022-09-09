using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetListProductsByCategory;

public class GetListProductsByCategoryQuery : IRequest<ProductListByCategoryModel>
{
    public PageRequest PageRequest { get; set; }

    public int CategoryId { get; set; }
    
    public class GetListProductsByCategoryQueryHandler : IRequestHandler<GetListProductsByCategoryQuery,ProductListByCategoryModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductsByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListByCategoryModel> Handle(GetListProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(p=>p.CategoryId==request.CategoryId,
                include: m=>m.Include(p=>p.Brand),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            ProductListByCategoryModel productListByCategoryModel = _mapper.Map<ProductListByCategoryModel>(products);

            return productListByCategoryModel;
        }
    }
}