using MediatR;

namespace Application.Category.Command;

public sealed record DeleteCategoryCommand(Guid id) : IRequest<bool>;
