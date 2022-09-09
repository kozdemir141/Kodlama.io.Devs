using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : Entity
{
    public string BrandName { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<Product> Products { get; set; }
}