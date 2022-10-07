using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
{
    public int Id { get; set; }

    public class
        DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);

            await _operationClaimRepository.DeleteAsync(operationClaim);
            DeletedOperationClaimDto deletedOperationClaimDto = _mapper.Map<DeletedOperationClaimDto>(operationClaim);

            return deletedOperationClaimDto;
        }
    }
}