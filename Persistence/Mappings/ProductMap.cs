using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        
        builder.Property(p => p.ProductName).IsRequired();
        builder.Property(p => p.ProductName).HasMaxLength(100);
        
        builder.Property(p => p.CategoryId).IsRequired();
        builder.Property(p => p.BrandId).IsRequired();
        
        builder.Property(p => p.Content).IsRequired();
        builder.Property(p => p.Content).HasColumnType("VARCHAR(1000)");
        
        builder.Property(p => p.UnitPrice).IsRequired();
        builder.Property(p => p.UnitsInStock).IsRequired();
        
        builder.Property(p => p.IsDeleted).IsRequired();
        
        builder.Property(p => p.CreatedDate).IsRequired();
        builder.Property(p => p.ModifiedDate).IsRequired();
        
        builder.HasOne<Category>(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

        builder.HasOne<Brand>(p => p.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);
        
        builder.ToTable("Products");

        builder.HasData(new Product
        {
            Id = 1,
            ProductName = "IdeaPad 3",
            CategoryId = 1,
            BrandId = 1,
            Content = "Intel Core i5 10210U 8GB 512GB SSD Freedos 15.6 FHD Taşınabilir Bilgisayar",
            UnitPrice = 9499,
            UnitsInStock = 10,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        },new Product
        {
            Id = 2,
            ProductName = "TUF Gaming FX506LH-HN004",
            CategoryId = 1,
            BrandId = 2,
            Content = "Intel Core i5 10300H 8GB 512GB SSD GTX1650 Freedos 15.6 FHD Taşınabilir Bilgisayar",
            UnitPrice = 13499,
            UnitsInStock = 15,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        },new Product
        {
            Id = 3,
            ProductName = "MacBook Air",
            CategoryId = 1,
            BrandId = 3,
            Content = "M2 Çip 8GB 256GB SSD macOS 13  Taşınabilir Bilgisayar Gece Yarısı",
            UnitPrice = 24599,
            UnitsInStock = 20,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        });
    }
}