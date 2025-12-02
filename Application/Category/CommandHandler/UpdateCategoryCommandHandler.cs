using Domain.Category;
using MediatR;


public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _categoryRepository = repository;
    }
    async Task<bool> IRequestHandler<UpdateCategoryCommand, bool>.Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByCategoryId(request.id, cancellationToken);

        if (category == null)
        {
            return false;
        }

       category.ChangeName(request.name);

        await _categoryRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
