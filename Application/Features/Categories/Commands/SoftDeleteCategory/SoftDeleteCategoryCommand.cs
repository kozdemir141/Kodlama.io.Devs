using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.SoftDeleteCategory;

public class SoftDeleteCategoryCommand : IRequest<SoftDeletedCategoryDto>
{
    public int Id { get; set; }

    public class SoftDeleteCategoryCommandHandler : IRequestHandler<SoftDeleteCategoryCommand, SoftDeletedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public SoftDeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<SoftDeletedCategoryDto> Handle(SoftDeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            category.IsDeleted = true;

            await _categoryRepository.UpdateAsync(category);
            SoftDeletedCategoryDto softDeletedCategoryDto = _mapper.Map<SoftDeletedCategoryDto>(category);

            return softDeletedCategoryDto;
        }
    }
}