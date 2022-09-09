using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Entities;

public class Product : Entity
{
    public string ProductName { get; set; }
    public string Content { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
}