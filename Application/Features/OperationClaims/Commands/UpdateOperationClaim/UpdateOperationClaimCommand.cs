using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public class
        UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            await _operationClaimRepository.UpdateAsync(operationClaim);
            UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(operationClaim);

            return updatedOperationClaimDto;
        }
    }
}