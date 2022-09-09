using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>
{
    public string CategoryName { get; set; }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryNameCanNotBeDublicatedWhenInserted(request.CategoryName);
            
            Category mappedCategory = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(mappedCategory);
            CreatedCategoryDto createdCategoryDto = _mapper.Map<CreatedCategoryDto>(mappedCategory);

            return createdCategoryDto;
        }
    }
}