using Application.Features.UserOfficialWebSites.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserOfficialWebSites.Commands.DeleteUserOfficialWebSite;

public class DeleteUserOfficialWebSiteCommand : IRequest<DeletedUserOfficialWebSiteDto>
{
    public int Id { get; set; }

    public class DeleteUserOfficialWebSiteCommandHandler : IRequestHandler<DeleteUserOfficialWebSiteCommand, DeletedUserOfficialWebSiteDto>
    {
        private readonly IUserOfficialWebSiteRepository _userOfficialWebSiteRepository;
        private readonly IMapper _mapper;

        public DeleteUserOfficialWebSiteCommandHandler(IUserOfficialWebSiteRepository userOfficialWebSiteRepository, IMapper mapper)
        {
            _userOfficialWebSiteRepository = userOfficialWebSiteRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserOfficialWebSiteDto> Handle(DeleteUserOfficialWebSiteCommand request, CancellationToken cancellationToken)
        {
            var userOfficialWebSite = await _userOfficialWebSiteRepository.GetAsync(w => w.Id == request.Id);

            await _userOfficialWebSiteRepository.DeleteAsync(userOfficialWebSite);

            DeletedUserOfficialWebSiteDto deletedUserOfficialWebSiteDto = _mapper.Map<DeletedUserOfficialWebSiteDto>(userOfficialWebSite);

            return deletedUserOfficialWebSiteDto;
        }
    }
}