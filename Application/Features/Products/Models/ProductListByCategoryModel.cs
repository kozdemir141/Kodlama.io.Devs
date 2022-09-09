using Application.Features.Products.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Products.Models;

public class ProductListByCategoryModel : BasePageableModel
{
    public IList<ProductListByCategoryDto> Items { get; set; }
}