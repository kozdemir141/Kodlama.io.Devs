using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetNonDeletedProducts;

public class GetNonDeletedListProductQuery : IRequest<ProductNonDeletedListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetNonDeletedListProductQueryHandler : IRequestHandler<GetNonDeletedListProductQuery,ProductNonDeletedListModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetNonDeletedListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductNonDeletedListModel> Handle(GetNonDeletedListProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(p=>!p.IsDeleted,
                include: m=>m.Include(p=>p.Brand),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            ProductNonDeletedListModel productNonDeletedListModel = _mapper.Map<ProductNonDeletedListModel>(products);

            return productNonDeletedListModel;
        }
    }
}