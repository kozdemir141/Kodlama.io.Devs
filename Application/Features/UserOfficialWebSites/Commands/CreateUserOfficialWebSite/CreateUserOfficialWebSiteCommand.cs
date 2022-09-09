using Application.Features.UserOfficialWebSites.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserOfficialWebSites.Commands.CreateUserOfficialWebSite;

public class CreateUserOfficialWebSiteCommand : IRequest<CreatedUserOfficialWebSiteDto>
{
    public int UserId { get; set; }
    
    public string ProfileUrl { get; set; }
    
    public class CreateUserOfficialWebSiteCommandHandler : IRequestHandler<CreateUserOfficialWebSiteCommand,CreatedUserOfficialWebSiteDto>
    {
        private readonly IUserOfficialWebSiteRepository _userOfficialWebSiteRepository;
        private readonly IMapper _mapper;

        public CreateUserOfficialWebSiteCommandHandler(IUserOfficialWebSiteRepository userOfficialWebSiteRepository, IMapper mapper)
        {
            _userOfficialWebSiteRepository = userOfficialWebSiteRepository;
            _mapper = mapper;
        }
        public async Task<CreatedUserOfficialWebSiteDto> Handle(CreateUserOfficialWebSiteCommand request, CancellationToken cancellationToken)
        {
            UserOfficialWebSite mappedUserOfficialWebSite = _mapper.Map<UserOfficialWebSite>(request);
            await _userOfficialWebSiteRepository.AddAsync(mappedUserOfficialWebSite);

            CreatedUserOfficialWebSiteDto createdUserOfficialWebSiteDto =
                _mapper.Map<CreatedUserOfficialWebSiteDto>(mappedUserOfficialWebSite);

            return createdUserOfficialWebSiteDto;
        }
    }
}