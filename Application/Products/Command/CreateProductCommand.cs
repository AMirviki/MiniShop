using MediatR;

namespace Application.Products.Command;

public sealed record CreateProductCommand(
    string name , 
    decimal price , 
    string description , 
    Guid categoryId) : IRequest<Guid>;
