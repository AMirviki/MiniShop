using Domain.Category;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class MiniShopDbContext : DbContext
{
    public MiniShopDbContext(DbContextOptions<MiniShopDbContext> options) : base(options)
    {

    }


    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiniShopDbContext).Assembly);
    }
}
