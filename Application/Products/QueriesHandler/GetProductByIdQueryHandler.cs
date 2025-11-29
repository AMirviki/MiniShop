using Application.Products.Dto;
using Application.Products.Interfaces;
using Application.Products.Queries;
using MediatR;

namespace Application.Products.QueriesHandler;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _productRepository = repository;
    }


    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.id, cancellationToken);

        if (product == null) 
        {
            return null;
        }

        return new ProductDto(
            product.Id,
            product.Name.Name,
            product.Price.Value,
            product.Description.Description,
            product.CategoryId
            );
    }
}
