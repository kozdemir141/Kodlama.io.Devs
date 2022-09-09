using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<DeletedProductDto>
{
    public int Id { get; set; }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<DeletedProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(p => p.Id == request.Id);

            await _productRepository.DeleteAsync(product);
            DeletedProductDto deletedProductDto = _mapper.Map<DeletedProductDto>(product);

            return deletedProductDto;
        }
    }
}