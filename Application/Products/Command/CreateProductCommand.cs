using MediatR;

namespace Application.Products.Command;

public record CreateProductCommand(
    string name , 
    decimal price , 
    string description , 
    Guid categoryId) : IRequest<Guid>;
