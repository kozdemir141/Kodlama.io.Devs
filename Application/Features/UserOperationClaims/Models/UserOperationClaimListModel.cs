using Application.Features.UserOperationClaims.Dtos;

namespace Application.Features.UserOperationClaims.Models;

public class UserOperationClaimListModel
{
    public IList<UserOperationClaimListDto> Items { get; set; }
}