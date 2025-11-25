using Domain.Products;

namespace Application.Products.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product , CancellationToken cancellationToken);
}
