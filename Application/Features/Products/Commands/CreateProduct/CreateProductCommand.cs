using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<CreatedProductDto>
{
    public string ProductName { get; set; }
    public int CategoryId { get; set; }

    public int BrandId { get; set; }
    public string Content { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product mappedProduct = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(mappedProduct);
            CreatedProductDto createdProductDto = _mapper.Map<CreatedProductDto>(mappedProduct);

            return createdProductDto;
        }
    }
}