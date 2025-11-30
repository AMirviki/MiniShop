using Application.Category.Command;
using MediatR;
using System.Drawing;

namespace Application.Category.CommandHandler;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = _repository.GetByCategoryId(request.id , cancellationToken);

        if (result == null) 
        {
            return false;
        }

        await _repository.RemoveCategoryById(result.Result.Id, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return true;    
    }
}
