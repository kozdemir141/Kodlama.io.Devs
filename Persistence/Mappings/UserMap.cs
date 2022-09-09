using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id");
        
        builder.Property(c => c.FirstName).HasColumnName("FirstName");
        builder.Property(c => c.LastName).HasColumnName("LastName");
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt");
        builder.Property(c => c.PasswordHash).HasColumnName("PasswordHash");
        builder.Property(c => c.Status).HasColumnName("Status");
        builder.Property(c => c.AuthenticatorType).HasColumnName("AuthenticatorType");
        
        builder.HasMany(c => c.UserOperationClaims);
        builder.HasMany(c => c.RefreshTokens);

        builder.ToTable("Users");
    }
}