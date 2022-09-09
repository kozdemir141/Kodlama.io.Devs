using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery : IRequest<CategoryGetByIdDto>
{
    public int Id { get; set; }
    
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery,CategoryGetByIdDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        //private readonly CategoryBusinessRules _categoryBusinessRules;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            //_categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CategoryGetByIdDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            //await _categoryBusinessRules.CategoryShouldExistWhenRequested(request.Id);
            Category category = await _categoryRepository.GetAsync(c => c.Id == request.Id);

            CategoryGetByIdDto categoryGetByIdDto = _mapper.Map<CategoryGetByIdDto>(category);

            return categoryGetByIdDto;
        }
    }
}