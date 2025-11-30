using Application.Products.Command;
using Application.Products.Interfaces;
using MediatR;

namespace Application.Products.CommandHandler;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public RemoveProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var result = _repository.GetByIdAsync(request.id, cancellationToken);

        if (result == null)
        {
            return false;
        }

        await _repository.RemoveProductById(result.Result.Id , cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
