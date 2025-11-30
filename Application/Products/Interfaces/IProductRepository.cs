using Domain.Products;

namespace Application.Products.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product , CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(Guid id , CancellationToken ct);

    Task<int> SaveChangesAsync(CancellationToken ct = default);

    Task RemoveProductById(Guid id , CancellationToken cancellationToken);   
}
