using Application.Features.Categories.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetNonDeletedListCategories;

public class GetNonDeletedListCategoryQuery : IRequest<CategoryNonDeletedListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetNonDeletedListCategoryQueryHandler : IRequestHandler<GetNonDeletedListCategoryQuery,CategoryNonDeletedListModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetNonDeletedListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryNonDeletedListModel> Handle(GetNonDeletedListCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categories = await _categoryRepository.GetListAsync(p=>!p.IsDeleted ,index: request.PageRequest.Page,size: request.PageRequest.PageSize);

            CategoryNonDeletedListModel categoryNonDeletedListModel = _mapper.Map<CategoryNonDeletedListModel>(categories);

            return categoryNonDeletedListModel;
        }
    }
}