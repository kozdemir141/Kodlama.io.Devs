namespace Application.Features.Brands.Dtos;

public class BrandGetByIdDto
{
    public int Id { get; set; }
    
    public string BrandName { get; set; }
    
    public bool IsDeleted { get; set; }
}