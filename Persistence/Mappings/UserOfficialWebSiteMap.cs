using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class UserOfficialWebSiteMap : IEntityTypeConfiguration<UserOfficialWebSite>
{
    public void Configure(EntityTypeBuilder<UserOfficialWebSite> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id");
        
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.ProfileUrl).HasColumnName("ProfileUrl");

        builder.HasOne(p => p.User);
        
        builder.ToTable("UserOfficialWebSites");
    }
}