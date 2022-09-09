using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.SoftDeleteProduct;

public class SoftDeleteProductCommand : IRequest<SoftDeletedProductDto>
{
    public int Id { get; set; }

    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand, SoftDeletedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SoftDeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<SoftDeletedProductDto> Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(p => p.Id == request.Id);
            product.IsDeleted = true;
            product.ModifiedDate = DateTime.Now;

            await _productRepository.UpdateAsync(product);
            SoftDeletedProductDto softDeletedProductDto = _mapper.Map<SoftDeletedProductDto>(product);

            return softDeletedProductDto;
        }
    }
}