using Application.Category.Command;
using Domain.Category;
using MediatR;


public class CategoryCommandHandler : IRequestHandler<CategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryCommandHandler(ICategoryRepository repository)
    {
        _categoryRepository = repository;
    }

    public async Task<Guid> Handle(CategoryCommand request, CancellationToken cancellationToken)
    {
        var nameVo = CategoryName.Create(request.name);
        var category = Category.Create(nameVo);

        await _categoryRepository.AddCategory(category, cancellationToken);

        return category.Id;
    }
}
