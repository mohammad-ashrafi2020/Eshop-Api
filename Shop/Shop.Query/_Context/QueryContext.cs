using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Domain.UserAgg;
using Shop.Infrastructure._Utilities.MediatR;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query._Context.Models;

namespace Shop.Query._Context;

class QueryContext : DbContext
{
    public QueryContext(DbContextOptions<QueryContext> options) : base(options)
    {
    }

    public DbSet<CommentQueryModel> Comments { get; set; }
    public DbSet<UserQueryModel> Users { get; set; }
    public DbSet<ProductQueryModel> Products { get; set; }
    public DbSet<InventoryQueryModel> Inventories { get; set; }
    public DbSet<SellerQueryModel> Seller { get; set; }
    public DbSet<CategoryQueryModel> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<CategoryQueryModel>()
            .OwnsOne(b => b.SeoData, config =>
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
            }); ;

        base.OnModelCreating(modelBuilder);
    }
}