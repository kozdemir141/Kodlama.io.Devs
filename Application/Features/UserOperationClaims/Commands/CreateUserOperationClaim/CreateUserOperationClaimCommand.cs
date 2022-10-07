using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
{
    public int UserId { get; set; }
    
    public int OperationClaimId { get; set; }

    public class
        CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,
            CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            await _userOperationClaimRepository.AddAsync(userOperationClaim);
            CreatedUserOperationClaimDto createdUserOperationClaimDto =
                _mapper.Map<CreatedUserOperationClaimDto>(userOperationClaim);
            return createdUserOperationClaimDto;
        }
    }
}