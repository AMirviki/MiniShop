using Application.Category.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Queries
{
    public sealed record class GetCategoryByIdQuery(Guid id) : IRequest<CategoryDto>;
    
}
