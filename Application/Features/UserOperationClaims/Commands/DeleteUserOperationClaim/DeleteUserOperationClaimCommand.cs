using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
{
    public int Id { get; set; }

    public class
        DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
            DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
            IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            await _userOperationClaimRepository.AddAsync(userOperationClaim);
            DeletedUserOperationClaimDto deletedUserOperationClaimDto =
                _mapper.Map<DeletedUserOperationClaimDto>(userOperationClaim);
            return deletedUserOperationClaimDto;
        }
    }
}