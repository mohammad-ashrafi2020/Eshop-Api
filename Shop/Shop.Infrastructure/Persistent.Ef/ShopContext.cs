using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CommentAgg;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.RoleAgg;
using Shop.Domain.SellerAgg;
using Shop.Domain.SiteEntities;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<SellerInventory> Inventories { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}