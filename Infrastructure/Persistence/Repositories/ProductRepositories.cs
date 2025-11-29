using Application.Products.Interfaces;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly MiniShopDbContext dbContext;

    public ProductRepository(MiniShopDbContext db)
    {
        dbContext = db;
    }


    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await dbContext.Products.AddAsync(product, cancellationToken);
        dbContext.SaveChanges();
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await dbContext.Products.FirstOrDefaultAsync(p=>p.Id == id , ct);
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return dbContext.SaveChangesAsync(ct);  
    }
}
