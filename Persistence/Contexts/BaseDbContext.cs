using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mappings;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost; database=ECommerceDataBase; user=root; password=55431921",
            ServerVersion.AutoDetect("server=localhost; database=ECommerceDataBase; user=root; password=55431921"));
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }

    //Auth
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    
    //User
    public DbSet<UserOfficialWebSite> UserOfficialWebSites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Detailed Mapping Process Added to the Persistence/Mappings...
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new BrandMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserOperationClaimMap());
        modelBuilder.ApplyConfiguration(new OperationClaimMap());
        modelBuilder.ApplyConfiguration(new UserOfficialWebSiteMap());
    }
}