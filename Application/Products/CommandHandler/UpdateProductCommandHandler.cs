using Application.Products.Command;
using Application.Products.Interfaces;
using Domain.Products;
using MediatR;

namespace Application.Products.CommandHandler;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.id , cancellationToken);

        if (product == null) 
        {
            return Guid.Empty;
        }

        product.ChangeName(request.name);
        product.ChangeDescription(request.description);
        product.ChangePrice(request.price);

        await _repository.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}
