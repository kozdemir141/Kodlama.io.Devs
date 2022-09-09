using Application.Features.Categories.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Categories.Models;

public class CategoryNonDeletedListModel : BasePageableModel
{
    public IList<CategoryNonDeletedListDto> Items { get; set; }
}