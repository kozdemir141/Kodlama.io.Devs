using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdatedProductDto>
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }

    public int BrandId { get; set; }
    public string Content { get; set; }

    public decimal UnitPrice { get; set; }

    public short UnitsInStock { get; set; }
    
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,UpdatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _productRepository.GetWithoutTrackingAsync(p => p.Id == request.Id);
            
            Product mappedProduct = _mapper.Map<Product>(request);
            mappedProduct.ModifiedDate = DateTime.Now;
            mappedProduct.CreatedDate = oldProduct.CreatedDate;

            await _productRepository.UpdateAsync(mappedProduct);
            UpdatedProductDto updatedProductDto = _mapper.Map<UpdatedProductDto>(mappedProduct);

            return updatedProductDto;
        }
    }
}