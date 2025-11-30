using Application.Products.Interfaces;
using Domain.Category;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepositories : ICategoryRepository
{

    private readonly MiniShopDbContext _dbContext;

    public CategoryRepositories(MiniShopDbContext db)
    {
        _dbContext = db;
    }

    public async Task AddCategory(Category category, CancellationToken ct)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Category> GetByCategoryId(Guid id, CancellationToken ct)
    {
        return await _dbContext.Categories
          .FirstOrDefaultAsync(c => c.Id == id, ct);
    }
    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _dbContext.SaveChangesAsync(ct);
    }

    async Task ICategoryRepository.RemoveCategoryById(Guid id, CancellationToken ct)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);

        _dbContext.Remove(category);

    }
}
