using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity
{
    public string CategoryName { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ICollection<Product> Products { get; set; }
    public ICollection<Brand> Brands { get; set; }
}