using Application.Category.Command;
using Application.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));

            if(result == null)
                return NotFound();


            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));

            if (result == false)

                return NotFound();


            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id , string name)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id,name));

            if (result == null)

                return NotFound();


            return Ok(result);
        }

    }
}
