namespace Application.Features.Products.Dtos;

public class UpdatedProductDto
{
    public string ProductName { get; set; }

    public int CategoryId { get; set; }
    
    public int BrandId { get; set; }

    public string Content { get; set; }

    public decimal UnitPrice { get; set; }

    public short UnitsInStock { get; set; }

    public bool IsDeleted { get; set; } = false;
}