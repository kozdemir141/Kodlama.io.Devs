namespace Application.Features.Categories.Dtos;

public class UpdatedCategoryDto
{
    public int Id { get; set; }
    
    public string CategoryName { get; set; }

    public bool IsDeleted { get; set; } = false;
}