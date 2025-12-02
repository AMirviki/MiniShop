using MediatR;


public sealed record UpdateProductCommand(
    Guid id,
    string name , 
    decimal price , 
    string description , 
    Guid categoryId) : IRequest<Guid>;
