using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id");
        
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

        builder.HasOne(c => c.OperationClaim);
        builder.HasOne(c => c.User);
        
        builder.ToTable("UserOperationClaims");
    }
}