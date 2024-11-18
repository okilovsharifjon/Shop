using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsonCommerce.Application.Features;

namespace OsonCommerce.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/storebranch")]
    public class StoreBranchController : ControllerBase 
    {
        private readonly IMediator _mediator;
        public StoreBranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStoreBranch([FromBody] CreateStoreBranchCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreBranchById([FromRoute] GetStoreBranchByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStoreBranch([FromBody] UpdateStoreBranchCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreBranch([FromRoute] DeleteStoreBranchCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStoreBranches([FromQuery] GetAllStoreBranchesQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }   
}
