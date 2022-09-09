using Application.Features.Products.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Products.Models;

public class ProductNonDeletedListModel : BasePageableModel
{
    public IList<ProductNonDeletedListDto> Items { get; set; }
}