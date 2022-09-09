using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>
{
    public int Id { get; set; }
    
    public string CategoryName { get; set; }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category mappedCategory  = _mapper.Map<Category>(request);
            await _categoryRepository.UpdateAsync(mappedCategory);
            UpdatedCategoryDto updatedCategoryDto = _mapper.Map<UpdatedCategoryDto>(mappedCategory);

            return updatedCategoryDto;
        }
    }
}