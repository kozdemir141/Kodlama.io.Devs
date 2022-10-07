using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
{
    public string Name { get; set; }

    public class
        CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
            await _operationClaimRepository.AddAsync(mappedOperationClaim);
            CreatedOperationClaimDto createdOperationClaimDto =
                _mapper.Map<CreatedOperationClaimDto>(mappedOperationClaim);

            return createdOperationClaimDto;
        }
    }
}