using Domain.Category;

public interface ICategoryRepository
{
    Task AddCategory(Category category, CancellationToken ct);

    Task<Category> GetByCategoryId(Guid id, CancellationToken ct);

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
