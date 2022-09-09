using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetByIdProduct;

public class GetByIdProductQuery : IRequest<ProductGetByIdDto>
{
    public int Id { get; set; }
    
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery,ProductGetByIdDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        //private readonly ProductBusinessRules _productBusinessRules;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            //_productBusinessRules = productBusinessRules;
        }

        public async Task<ProductGetByIdDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            //await _productBusinessRules.ProductShouldExistWhenRequested(request.Id);
            
            Product product = await _productRepository.GetAsync(p => p.Id == request.Id);

            ProductGetByIdDto productGetByIdDto = _mapper.Map<ProductGetByIdDto>(product);

            return productGetByIdDto;
        }
    }
}