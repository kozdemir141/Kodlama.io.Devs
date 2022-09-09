using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.CategoryName).IsRequired();
        builder.Property(c => c.CategoryName).HasMaxLength(50);
        
        builder.Property(c => c.IsDeleted).IsRequired();

        builder.HasMany(c => c.Brands);
        builder.HasMany(c => c.Products);
        
        builder.ToTable("Categories");
        
        builder.HasData(new Category
        {
            Id = 1,
            CategoryName = "Laptop",
            IsDeleted = false
        });
    }
}