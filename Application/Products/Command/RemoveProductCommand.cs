using MediatR;

namespace Application.Products.Command;

public sealed record class RemoveProductCommand (Guid id) : IRequest<bool>;
