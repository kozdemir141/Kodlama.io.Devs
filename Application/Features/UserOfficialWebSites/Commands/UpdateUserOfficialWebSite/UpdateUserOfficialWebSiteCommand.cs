using Application.Features.UserOfficialWebSites.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserOfficialWebSites.Commands.UpdateUserOfficialWebSite;

public class UpdateUserOfficialWebSiteCommand : IRequest<UpdatedUserOfficialWebSiteDto>
{
    public int Id { get; set; }

    public int UserId { get; set; }
    
    public string ProfileUrl { get; set; }

    public class UpdateUserOfficialWebSiteCommandHandler : IRequestHandler<UpdateUserOfficialWebSiteCommand, UpdatedUserOfficialWebSiteDto>
    {
        private readonly IUserOfficialWebSiteRepository _userOfficialWebSiteRepository;
        private readonly IMapper _mapper;

        public UpdateUserOfficialWebSiteCommandHandler(IUserOfficialWebSiteRepository userOfficialWebSiteRepository, IMapper mapper)
        {
            _userOfficialWebSiteRepository = userOfficialWebSiteRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserOfficialWebSiteDto> Handle(UpdateUserOfficialWebSiteCommand request, CancellationToken cancellationToken)
        {
            UserOfficialWebSite mappedUserOfficialWebSite = _mapper.Map<UserOfficialWebSite>(request);

            await _userOfficialWebSiteRepository.UpdateAsync(mappedUserOfficialWebSite);

            UpdatedUserOfficialWebSiteDto updatedUserOfficialWebSiteDto = _mapper.Map<UpdatedUserOfficialWebSiteDto>(mappedUserOfficialWebSite);

            return updatedUserOfficialWebSiteDto;
        }
    }
}