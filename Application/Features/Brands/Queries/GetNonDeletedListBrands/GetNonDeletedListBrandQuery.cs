using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetNonDeletedListBrands;

public class GetNonDeletedListBrandQuery : IRequest<BrandNonDeletedListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetNonDeletedListBrandQueryHandler : IRequestHandler<GetNonDeletedListBrandQuery,BrandNonDeletedListModel>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetNonDeletedListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandNonDeletedListModel> Handle(GetNonDeletedListBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Brand> brands = await _brandRepository.GetListAsync(b=>!b.IsDeleted ,index: request.PageRequest.Page,size: request.PageRequest.PageSize);

            BrandNonDeletedListModel brandNonDeletedListModel = _mapper.Map<BrandNonDeletedListModel>(brands);

            return brandNonDeletedListModel;
        }
    }
}