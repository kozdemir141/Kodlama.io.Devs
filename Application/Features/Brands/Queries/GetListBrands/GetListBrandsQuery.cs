using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListBrands;

public class GetListBrandQuery : IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandsQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page,size: request.PageRequest.PageSize);

            BrandListModel categoryListModel = _mapper.Map<BrandListModel>(brands);

            return categoryListModel;
        }
    }
}