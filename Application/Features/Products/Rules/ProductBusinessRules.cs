using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task ProductShouldExistWhenRequested(int id)
    {
        Product? product = await _productRepository.GetAsync(p => p.Id == id);
        if (product == null) throw new BusinessException("Requested Product Does Not Exist");
    }
}