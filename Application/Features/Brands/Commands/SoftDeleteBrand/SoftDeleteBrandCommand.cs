using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.SoftDeleteBrand;

public class SoftDeleteBrandCommand : IRequest<SoftDeletedBrandDto>
{
    public int Id { get; set; }

    public class SoftDeleteBrandCommandHandler : IRequestHandler<SoftDeleteBrandCommand, SoftDeletedBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public SoftDeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<SoftDeletedBrandDto> Handle(SoftDeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
            brand.IsDeleted = true;

            await _brandRepository.UpdateAsync(brand);
            SoftDeletedBrandDto softDeletedBrandDto = _mapper.Map<SoftDeletedBrandDto>(brand);

            return softDeletedBrandDto;
        }
    }
}