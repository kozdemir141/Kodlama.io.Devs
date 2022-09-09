using Application.Features.Products.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Products.Models;

public class ProductListByBrandModel : BasePageableModel
{
    public IList<ProductListByBrandDto> Items { get; set; }
}