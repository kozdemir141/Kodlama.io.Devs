using Application.Features.OperationClaims.Dtos;

namespace Application.Features.OperationClaims.Models;

public class OperationClaimListModel
{
    public IList<OperationClaimListDto> Items { get; set; }
}