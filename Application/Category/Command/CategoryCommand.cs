using MediatR;

namespace Application.Category.Command;

public sealed record CategoryCommand(
    string name
    ) : IRequest<Guid>;

