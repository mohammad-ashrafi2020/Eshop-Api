using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "product");
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(b => b.Description)
            .IsRequired();

        builder.Property(b => b.ImageName)
            .IsRequired()
            .HasMaxLength(110);

        builder.Property(b => b.Slug)
            .IsRequired()
            .IsUnicode(false);

        builder.OwnsOne(b => b.SeoData, config =>
        {
            config.Property(b => b.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("MetaDescription");

            config.Property(b => b.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("MetaTitle");

            config.Property(b => b.MetaKeyWords)
                .HasMaxLength(500)
                .HasColumnName("MetaKeyWords");

            config.Property(b => b.IndexPage)
                .HasColumnName("IndexPage");

            config.Property(b => b.Canonical)
                .HasMaxLength(500)
                .HasColumnName("Canonical");

            config.Property(b => b.Schema)
                .HasColumnName("Schema");
        });

        builder.OwnsMany(b => b.Images, option =>
        {
            option.ToTable("Images", "product");
            option.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(100);
        });


        builder.OwnsMany(b => b.Specifications, option =>
        {
            option.ToTable("Specifications", "product");

            option.Property(b => b.Key)
                .IsRequired()
                .HasMaxLength(50);

            option.Property(b => b.Key)
                .IsRequired()
                .HasMaxLength(100);
        });
    }
}