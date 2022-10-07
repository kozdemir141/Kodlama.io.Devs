using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public class
        UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,
            UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto =
                _mapper.Map<UpdatedUserOperationClaimDto>(userOperationClaim);
            return updatedUserOperationClaimDto;
        }
    }
}