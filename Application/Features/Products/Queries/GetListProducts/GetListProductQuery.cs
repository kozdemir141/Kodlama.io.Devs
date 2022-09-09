using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetListProducts;

public class GetListProductQuery : IRequest<ProductListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery,ProductListModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(include:
                m=>m.Include(p=>p.Brand),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            ProductListModel productListModel = _mapper.Map<ProductListModel>(products);

            return productListModel;
        }
    }
}