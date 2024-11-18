using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsonCommerce.Application.Features;

namespace OsonCommerce.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/manufacture")]
    public class ManufactureController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ManufactureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacture([FromBody] CreateManufactureCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufactureById([FromRoute] GetManufactureByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManufacture([FromBody] UpdateManufactureCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacture([FromRoute] DeleteManufactureCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManufactures([FromQuery] GetAllManufacturesQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
