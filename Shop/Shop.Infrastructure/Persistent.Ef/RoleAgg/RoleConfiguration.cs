using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "role");
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.OwnsMany(b => b.Permissions, option =>
        {
            option.ToTable("Permissions", "role");
        });
    }
}