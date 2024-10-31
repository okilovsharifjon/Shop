using MediatR;
using Microsoft.AspNetCore.Mvc;
using OsonCommerce.Application.Features;

namespace OsonCommerce.Web.Controllers;   

[ApiController]
[Route("api/provider")]
public class ProviderController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProviderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProviderCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllProvidersQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(GetProviderByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProviderCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeleteProviderCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}
