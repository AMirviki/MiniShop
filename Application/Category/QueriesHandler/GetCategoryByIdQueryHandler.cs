using Application.Category.Dto;
using Application.Category.Queries;
using MediatR;

namespace Application.Category.QueriesHandler;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryByIdQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByCategoryId(request.id , cancellationToken);

        if (category == null)
        {
            return null;
        }

        return new CategoryDto(
            category.Id,
            category.Name.Name
            );
    }
}
