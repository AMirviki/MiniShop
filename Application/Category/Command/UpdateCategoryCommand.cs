using Domain.Category;
using MediatR;


public sealed record UpdateCategoryCommand(Guid id , string name ) : IRequest<bool>;

