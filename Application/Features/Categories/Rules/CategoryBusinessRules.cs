using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CategoryNameCanNotBeDublicatedWhenInserted(string name)
    {
        IPaginate<Category> result = await _categoryRepository.GetListAsync(c => c.CategoryName == name);
        if (result.Items.Any()) throw new BusinessException(CategoryMessages.CategoryNameExist);
    }
    public async Task CategoryShouldExistWhenRequested(int id)
    {
        Category? category = await _categoryRepository.GetAsync(c => c.Id == id);
        if (category == null) throw new BusinessException(CategoryMessages.CategoryMustExist);
    }
}