using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class BrandMap : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        
        builder.Property(b => b.BrandName).IsRequired();
        builder.Property(b => b.BrandName).HasMaxLength(30);
        
        builder.Property(b => b.IsDeleted).IsRequired();

        builder.HasMany(b => b.Products);
        
        builder.ToTable("Brands");

        builder.HasData(new Brand
        {
            Id = 1,
            BrandName = "Lenovo",
            IsDeleted = false
        },
        new Brand
        {
            Id = 2,
            BrandName = "Asus",
            IsDeleted = false
        },
        new Brand
        {
            Id = 3,
            BrandName = "Apple",
            IsDeleted = false
        });
    }
}