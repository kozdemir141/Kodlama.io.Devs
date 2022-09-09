using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.UndoDeleteProduct;

public class UndoDeleteProductCommand : IRequest<UndoDeletedProductDto>
{
    public int Id { get; set; }

    public class UndoDeleteProductCommandHandler : IRequestHandler<UndoDeleteProductCommand, UndoDeletedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UndoDeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UndoDeletedProductDto> Handle(UndoDeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(p => p.Id == request.Id);
            product.IsDeleted = false;
            product.ModifiedDate = DateTime.Now;

            await _productRepository.UpdateAsync(product);
            UndoDeletedProductDto softDeletedProductDto = _mapper.Map<UndoDeletedProductDto>(product);

            return softDeletedProductDto;
        }
    }
}