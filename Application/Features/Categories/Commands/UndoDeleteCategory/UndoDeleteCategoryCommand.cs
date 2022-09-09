using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.UndoDeleteCategory;

public class UndoDeleteCategoryCommand : IRequest<UndoDeletedCategoryDto>
{
    public int Id { get; set; }

    public class UndoDeleteCategoryCommandHandler : IRequestHandler<UndoDeleteCategoryCommand, UndoDeletedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public UndoDeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<UndoDeletedCategoryDto> Handle(UndoDeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            category.IsDeleted = false;
            
            await _categoryRepository.UpdateAsync(category);
            UndoDeletedCategoryDto undoDeletedCategoryDto = _mapper.Map<UndoDeletedCategoryDto>(category);

            return undoDeletedCategoryDto;
        }
    }
}