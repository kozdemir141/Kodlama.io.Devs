namespace Application.Features.Products.Dtos;

public class ProductNonDeletedListDto
{
    public int Id { get; set; }
    
    public string ProductName { get; set; }

    public int CategoryId { get; set; }
    public string BrandName { get; set; }
    
    public int BrandId { get; set; }

    public string Content { get; set; }

    public decimal UnitPrice { get; set; }

    public short UnitsInStock { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}