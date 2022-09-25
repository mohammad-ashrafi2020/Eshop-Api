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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        base.OnModelCreating(modelBuilder);
    }
}