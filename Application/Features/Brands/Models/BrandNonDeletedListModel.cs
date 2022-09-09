using Application.Features.Brands.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Brands.Models;

public class BrandNonDeletedListModel : BasePageableModel
{
    public IList<BrandNonDeletedListDto> Items { get; set; }
}