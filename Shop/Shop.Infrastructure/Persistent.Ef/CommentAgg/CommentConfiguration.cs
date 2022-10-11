using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CommentAgg;
using Shop.Domain.ProductAgg;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentConfiguration:IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(f => f.ProductId);
    }
}