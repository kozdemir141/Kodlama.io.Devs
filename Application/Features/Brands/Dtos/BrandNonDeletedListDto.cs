namespace Application.Features.Brands.Dtos;

public class BrandNonDeletedListDto
{
    public int Id { get; set; }
    
    public string BrandName { get; set; }
    
    public bool IsDeleted { get; set; }
}