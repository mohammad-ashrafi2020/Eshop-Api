using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CategoryAgg;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo");

            builder.HasKey(x => x.Id);
            builder.HasIndex(b => b.Slug).IsUnique();

            builder.Property(b => b.Slug)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(b => b.Title)
                .IsRequired();

            builder
                .HasMany(b => b.Childs)
                .WithOne()
                .HasForeignKey(b => b.ParentId);

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
        }
    }
}