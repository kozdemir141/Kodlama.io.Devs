using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.UndoDeleteBrand;

public class UndoDeleteBrandCommand : IRequest<UndoDeletedBrandDto>
{
    public int Id { get; set; }

    public class UndoDeleteBrandCommandHandler : IRequestHandler<UndoDeleteBrandCommand, UndoDeletedBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public UndoDeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<UndoDeletedBrandDto> Handle(UndoDeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
            brand.IsDeleted = false;

            await _brandRepository.UpdateAsync(brand);
            UndoDeletedBrandDto undoDeletedBrandDto = _mapper.Map<UndoDeletedBrandDto>(brand);

            return undoDeletedBrandDto;
        }
    }
}