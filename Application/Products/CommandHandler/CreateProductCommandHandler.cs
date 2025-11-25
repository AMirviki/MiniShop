using Application.Products.Command;
using Application.Products.Interfaces;
using Domain.Products;
using MediatR;

namespace Application.Products.CommandHandler;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var nameVo = ProductName.Create(request.name);
        var priceVo = ProductPrice.Create(request.price);
        var descVo = DescriptionProduct.Create(request.description);

        var product = Product.Create(nameVo, priceVo, descVo, request.categoryId );

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}
