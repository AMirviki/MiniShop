using Application.Products.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries;

public sealed record class GetProductByIdQuery(Guid id) : IRequest<ProductDto?>; 
